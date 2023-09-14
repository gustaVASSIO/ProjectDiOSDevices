import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Device, DeviceFiles } from '@app/models/device.model';
import { Observable } from 'rxjs';

@Injectable()
export class DeviceService {

  constructor(private http: HttpClient) { }

  public getAllDevice() : Observable<Device[]>{
    return this.http.get<Device[]>(`${environment.DeviceAPI}/Devices`)
  }

  public getDeviceById(id : string) : Observable<Device>{
    return this.http.get<Device>(`${environment.DeviceAPI}/Devices/${id}`)
  }

  public postDevice(formData : FormData) : Observable<Device>{
    console.log("Passou no service", formData);
    return this.http.post<Device>(`${environment.DeviceAPI}/Devices`, formData)
  }

  public putDevice(id: string, formData : FormData) : Observable<Device>{
   return this.http.put<Device>(`${environment.DeviceAPI}/Devices/${id}`, formData)
  }

  public uploadFile(id: string, deviceFiles : FormData) : Observable<any>{
    return this.http.patch<any>(`${environment.DeviceAPI}/Devices/${id}`, deviceFiles )
  }

  public postTestDevice(formData : FormData) : Observable<Device>{
    console.log("Form Data for Back-End", formData)
    return this.http.post<Device>(`${environment.DeviceAPI}/Devices/TestFile`,formData)
  }

}
