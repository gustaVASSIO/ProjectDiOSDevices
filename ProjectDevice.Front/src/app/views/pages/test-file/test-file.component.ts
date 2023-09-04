import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DeviceService } from '@app/services/device.service';

@Component({
  selector: 'app-test-file',
  templateUrl: './test-file.component.html',
  styleUrls: ['./test-file.component.scss'],
  providers:[DeviceService]
})
export class TestFileComponent implements OnInit {

  private fotoFile !: File;
  private documentFile !: File

  public formDevice: FormGroup = new FormGroup({
    name: new FormControl(undefined),
    description: new FormControl(undefined),
  })
  
  constructor(private service: DeviceService) { }

  ngOnInit(): void {
  
  }

  public register(){
    const formData = new FormData()
    formData.set("name", this.formDevice.value.name)
    formData.set("description", this.formDevice.value.name)
    console.log("Foto for formData", this.fotoFile);
    
    formData.set("foto", this.fotoFile)
    formData.set("document", this.documentFile)
    console.log(formData)
    this.service.postTestDevice(formData).subscribe()
  }

  public setFotoFile(event: any) {
    this.fotoFile =  event.target.files[0];
    console.log(this.fotoFile)
  }

  public setDocumentFile(event: any) {
    this.documentFile = event.target.files[0];
  }
}
