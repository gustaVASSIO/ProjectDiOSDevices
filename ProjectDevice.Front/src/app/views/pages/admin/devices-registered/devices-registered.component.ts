import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { DeviceService } from '@app/services/device.service';
import { Device } from '@app/models/device.model';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-devices-registered',
  templateUrl: './devices-registered.component.html',
  styleUrls: ['./devices-registered.component.scss'],
  providers: [DeviceService]
})
export class DevicesRegisteredComponent implements OnInit {

  public displayedColumns = ["name", "description", "documantation", "actions"]

  public devicesDataSource$ !: Observable<Device[]>
 
  public files = environment.URLFiles

  constructor(
    private deviceService: DeviceService,
    private readonly _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.devicesDataSource$ = this.deviceService.getAllDevice()
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
