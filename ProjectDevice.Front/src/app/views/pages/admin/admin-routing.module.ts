import { DevicesRegisteredComponent } from './devices-registered/devices-registered.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { FormDeviceComponent } from './form-device/form-device.component';


const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    pathMatch: 'prefix',
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'devices-registered'
      },
      {
        path:'devices-registered',
        component:DevicesRegisteredComponent
      },
      {
        path:'register-device',
        component:FormDeviceComponent
      },
      {
        path:'edit-device/:id',
        component:FormDeviceComponent
      }
    ] 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
