import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Device } from '@app/models/device.model';
import { DeviceService } from '@app/services/device.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-details-device',
  templateUrl: './details-device.component.html',
  styleUrls: ['./details-device.component.scss'],
  providers:[DeviceService]
})
export class DetailsDeviceComponent implements OnInit {
  public deviceDetails !: Observable<Device>
  public readonly fileURL = environment.URLFiles
  constructor(
    private readonly deviceService : DeviceService,
    private readonly route : ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params : Params) =>{
      this. deviceDetails = this.deviceService.getDeviceById(params['id'])

    })
  }

}
