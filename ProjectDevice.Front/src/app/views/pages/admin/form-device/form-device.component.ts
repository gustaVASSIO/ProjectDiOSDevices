import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Device, DeviceFiles } from '@app/models/device.model';
import Subscription from '@app/models/subscription.model';
import { DeviceService } from '@app/services/device.service';
import { SubscriptionService } from '@app/services/subscription.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-form-device',
  templateUrl: './form-device.component.html',
  styleUrls: ['./form-device.component.scss'],
  providers: [DeviceService, SubscriptionService]
})
export class FormDeviceComponent implements OnInit {
  public isEditing: boolean = false
  public device?: Device
  public files: string = environment.URLFiles
  private subscriptionsNumberOfFields: number = 0
  public arraySubscriptiosForGenerateInputs: number[] = []

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
    private readonly route: ActivatedRoute

  ) { }

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
  }

  public registerDevice() {
    const susbscriptions: Subscription[] = []
    const formData: FormData = new FormData()

    formData.append("name", this.formDevice.value.name)
    formData.append("description", this.formDevice.value.description)
    formData.append("foto", this.fotoFile)
    formData.append("document", this.documentFile)

    this.deviceService.postDevice(formData).subscribe((device) => {
      this.arraySubscriptiosForGenerateInputs.forEach(e => {
        susbscriptions.push({
          title: this.formDevice.controls['subscription_title_' + e].value,
          description: this.formDevice.controls['subscription_description_' + e].value,
          deviceId: device.deviceId
        } as Subscription)
      })

      this.subscriptionService.putSubscription(susbscriptions).subscribe()
    })

  }

  public updateDevice() {
    const susbscriptions: Subscription[] = []
    const formData: FormData = new FormData()

    formData.append("name", this.formDevice.value.name)
    formData.append("description", this.formDevice.value.description)
    formData.append("foto", this.fotoFile)
    formData.append("document", this.documentFile)


    this.deviceService.putDevice(this.idDeviceForEdit, formData).subscribe(device =>{
      // this.arraySubscriptiosForGenerateInputs.forEach(e => {
      //   susbscriptions.push({
      //     title: this.formDevice.controls['subscription_title_' + e].value,
      //     description: this.formDevice.controls['subscription_description_' + e].value,
      //     deviceId: device.deviceId
        
      //   } as Subscription)
      // })
      
      // this.subscriptionService.putSubscription(susbscriptions).subscribe()
    })
  }

  public setFotoFile(event: any) {
    this.fotoFile = event.target.files[0];
    console.log(this.fotoFile);

    this.formDevice.patchValue({ fotoName: this.fotoFile.name })
    console.log(this.formDevice.value.fotoName);
  }

  public setDocumentFile(event: any) {
    this.documentFile = event.target.files[0];
    this.formDevice.patchValue({ documentName: this.documentFile.name })
  }

  public addSubscriptionOnForms() {
    this.subscriptionsNumberOfFields++
    this.arraySubscriptiosForGenerateInputs = [...Array(this.subscriptionsNumberOfFields).keys()]
    this.formDevice.addControl(`subscription_title_${this.subscriptionsNumberOfFields - 1}`, new FormControl(undefined))
    this.formDevice.addControl(`subscription_description_${this.subscriptionsNumberOfFields - 1}`, new FormControl(undefined))

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

      console.log(this.formDevice.controls);

    })
  }
}
