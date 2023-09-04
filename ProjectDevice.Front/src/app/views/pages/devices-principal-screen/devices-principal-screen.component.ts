import { MatSnackBar } from '@angular/material/snack-bar';
import { Device } from './../../../models/device.model';
import { Component, OnInit } from '@angular/core';
import { DeviceService } from '@app/services/device.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-devices-principal-screen',
  templateUrl: './devices-principal-screen.component.html',
  styleUrls: ['./devices-principal-screen.component.scss'],
  providers:[DeviceService]
})
export class DevicesPrincipalScreenComponent implements OnInit {

  public devices$ !: Observable<Device[]>
  
  public fileURL : string = environment.URLFiles

  constructor
  (
    private readonly deviceService: DeviceService,
    private readonly _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.devices$ = this.deviceService.getAllDevice()
  }
  
  public handleDownloadDocument(documentId : string){
    if(documentId != null){
      window.open(environment.URLFiles + documentId, "_blank")
    
    }else{
      this._snackBar.open("No document available yet", undefined,{
        duration:2000,
        panelClass:'doucment-unavailable-warning'
      });
    }
  }
}
