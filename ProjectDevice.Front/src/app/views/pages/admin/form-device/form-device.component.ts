import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Device, DeviceFiles } from '@app/models/device.model';
import { DeviceService } from '@app/services/device.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-form-device',
  templateUrl: './form-device.component.html',
  styleUrls: ['./form-device.component.scss'],
  providers: [DeviceService]
})
export class FormDeviceComponent implements OnInit {
  public isEditing : boolean = false
  public device ?: Device
  public files : string  = environment.URLFiles
  
  private idDeviceForEdit = ''
  private fotoFile !: File;
  private documentFile !: File

  public formDevice: FormGroup = new FormGroup({
    name: new FormControl(undefined, [Validators.required]),
    description: new FormControl(undefined, [Validators.required]),
  })
  
  constructor(
    private readonly deviceService: DeviceService,
    private readonly route : ActivatedRoute
    
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params : Params) => {
      if(params['id'] != null){
        this.isEditing = true
        this.idDeviceForEdit = params['id']
        
        this.loadFormsForEdit(this.idDeviceForEdit)
      }else{
        this.isEditing = false
      }

    })
  }

  public registerDevice() {

    const formData : FormData = new FormData()
    
    formData.append("name", this.formDevice.value.name)
    formData.append("description", this.formDevice.value.description)
    formData.append("foto", this.fotoFile)
    formData.append("document", this.documentFile)

    this.deviceService.postDevice(formData).subscribe()
  }

  public updateDevice(){
    const device : Device = { 
      deviceId : this.idDeviceForEdit,
      name : this.formDevice.value.name,
      description : this.formDevice.value.description,
      fotoPath : this.device?.fotoPath,
      documentPath : this.device?.documentPath
    }
    console.log(device);
    
    this.deviceService.putDevice(device).subscribe()
  }

  public setFotoFile(event: any) {
    const file: File = event.target.files[0];
    this.fotoFile = file
  }

  public setDocumentFile(event: any) {
    const file: File = event.target.files[0];
    this.documentFile = file
  }

  private loadFormsForEdit(id : string){
    this.deviceService.getDeviceById(id).subscribe((data) =>{
      this.device = data
      this.formDevice.patchValue({
        name : data.name,
        description : data.description
      })

    })
  }
}
