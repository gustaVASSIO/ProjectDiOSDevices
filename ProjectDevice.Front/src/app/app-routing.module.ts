import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DevicesPrincipalScreenComponent } from './views/pages/devices-principal-screen/devices-principal-screen.component';
import { DetailsDeviceComponent } from './views/pages/details-device/details-device.component';

const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () => import('./views/pages/admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'devices',
    component:  DevicesPrincipalScreenComponent
  },
  {
    path: 'device/:id',
    component:  DetailsDeviceComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
