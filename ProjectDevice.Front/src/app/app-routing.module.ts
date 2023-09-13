import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DevicesPrincipalScreenComponent } from './views/pages/devices-principal-screen/devices-principal-screen.component';
import { DetailsDeviceComponent } from './views/pages/details-device/details-device.component';
import { LoginComponent } from './views/pages/login/login.component';
import AuthGuard from './guards/authGuard.guard';
import SignGuard from './guards/signGuard.guard';

const routes: Routes = [
  {
    path:'',
    pathMatch:'full',
    redirectTo:'devices'
  },
  {
    path: 'admin',
    loadChildren: () => import('./views/pages/admin/admin.module').then(m => m.AdminModule),
    canActivate:[AuthGuard]
  },
  {
    path: 'devices',
    component:  DevicesPrincipalScreenComponent
  },
  {
    path: 'device/:id',
    component:  DetailsDeviceComponent
  },
  {
    path: 'login',
    component:  LoginComponent,
    canActivate: [SignGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
