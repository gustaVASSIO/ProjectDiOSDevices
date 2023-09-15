import { MessageService } from 'primeng/api';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Device } from '@app/models/device.model';
import Subscription from '@app/models/subscription.model';
import { DeviceService } from '@app/services/device.service';
import { SubscriptionService } from '@app/services/subscription.service';
import { environment } from 'src/environments/environment';
import Message from '@app/shared/message';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-form-device',
  templateUrl: './form-device.component.html',
  styleUrls: ['./form-device.component.scss'],
  providers: [DeviceService, SubscriptionService, MessageService]
})
export class FormDeviceComponent implements OnInit {
  public isEditing: boolean = false
  public device?: Device
  public files: string = environment.URLFiles
  private subscriptionsNumberOfFields: number = 0
  public arraySubscriptiosForGenerateInputs: number[] = []
  public readonly message: Message;

  public formDevice: FormGroup = new FormGroup({
    name: new FormControl(undefined, [Validators.required]),
    description: new FormControl(undefined, [Validators.required]),
    fotoName: new FormControl("No foto chosen"),
    documentName: new FormControl("No document chosen")
  })

  private idDeviceForEdit = ''
  private fotoFile !: File;
  private documentFile !: File

  constructor(
    private readonly deviceService: DeviceService,
    private readonly subscriptionService: SubscriptionService,
    private readonly route: ActivatedRoute,
    private messageService: MessageService,
    private router: Router,
  ) {
    this.message = new Message(messageService, router)
  }

  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      if (params['id'] != null) {
        this.isEditing = true
        this.idDeviceForEdit = params['id']

        this.loadFormsForEdit(this.idDeviceForEdit)
      } else {
        this.isEditing = false
      }

    })
    console.log(this.formDevice);
    
  }

  public registerDevice() {
    const susbscriptions: Subscription[] = []
    const formData: FormData = new FormData()

    formData.append("name", this.formDevice.value.name)
    formData.append("description", this.formDevice.value.description)
    formData.append("foto", this.fotoFile)
    formData.append("document", this.documentFile)

    this.deviceService.postDevice(formData).subscribe({
      next:(device) => {
        this.arraySubscriptiosForGenerateInputs.forEach(e => {
          susbscriptions.push({
            title: this.formDevice.controls['subscription_title_' + e].value,
            description: this.formDevice.controls['subscription_description_' + e].value,
            deviceId: device.deviceId
          } as Subscription)
        })

        this.subscriptionService.postSubscriptions(susbscriptions).subscribe({
          next: () => this.message.messageSuccess(`Device ${device.name} created with success`),
          error: (e) => this.message.messageError(`Error `),
        })
      },

      error: (e : HttpErrorResponse) => {        
        e.error.errors[""].forEach((error : string[]) => {
          this.message.messageError(`${error}`)
          
        });
      }
    }
    )

  }

  public updateDevice() {
    const susbscriptions: Subscription[] = []
    const formData: FormData = new FormData()

    formData.append("name", this.formDevice.value.name)
    formData.append("description", this.formDevice.value.description)
    formData.append("foto", this.fotoFile)
    formData.append("document", this.documentFile)


    this.deviceService.putDevice(this.idDeviceForEdit, formData).subscribe(device => {
      this.arraySubscriptiosForGenerateInputs.forEach((e) => {
        susbscriptions.push({
          subscriptionId: this.device?.subscriptions[e].subscriptionId,
          title: this.formDevice.controls['subscription_title_' + e].value,
          description: this.formDevice.controls['subscription_description_' + e].value,
          deviceId: this.device?.deviceId

        } as Subscription)
      })
      this.subscriptionService.putSubscription(susbscriptions).subscribe(() => {
        this.message.messageSuccess("Device updated with success")
      })
    })
  }

  public setFotoFile(event: any) {
    this.fotoFile = event.target.files[0];
    this.formDevice.patchValue({ fotoName: this.fotoFile.name })
  }

  public setDocumentFile(event: any) {
    this.documentFile = event.target.files[0];
    this.formDevice.patchValue({ documentName: this.documentFile.name })
  }

  public addSubscriptionOnForms() {
    this.subscriptionsNumberOfFields++
    this.arraySubscriptiosForGenerateInputs = [...Array(this.subscriptionsNumberOfFields).keys()]
    this.formDevice.addControl(`subscription_title_${this.subscriptionsNumberOfFields - 1}`, new FormControl(undefined, Validators.required))
    this.formDevice.addControl(`subscription_description_${this.subscriptionsNumberOfFields - 1}`, new FormControl(undefined, Validators.required))

  }

  public deleteSubscriptionFromForms() {
    this.formDevice.removeControl(`subscription_title_${this.subscriptionsNumberOfFields - 1}`)
    this.formDevice.removeControl(`subscription_description_${this.subscriptionsNumberOfFields - 1}`)
    this.subscriptionsNumberOfFields--
    this.arraySubscriptiosForGenerateInputs = [...Array(this.subscriptionsNumberOfFields).keys()]
  }


  public deleteSubscription() {
  }

  private loadFormsForEdit(id: string) {
    this.deviceService.getDeviceById(id).subscribe((data) => {
      this.device = data
      this.formDevice.patchValue({
        name: data.name,
        description: data.description
      })

      data.subscriptions.forEach((subs, i) => {
        this.addSubscriptionOnForms()
        this.formDevice.controls['subscription_title_' + i].patchValue(subs.title)
        this.formDevice.controls['subscription_description_' + i].patchValue(subs.description)
      });
    })
  }
}
