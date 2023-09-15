import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DevicesRegisteredComponent } from './devices-registered/devices-registered.component';
import { FormDeviceComponent } from './form-device/form-device.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AdminMaterialModule } from '@app/matarial/admin.material.module';
import { ShortDescriptionPipe } from '@app/shared/pipes/short-description.pipe';
import { InterceptorModule } from '@app/interceptors/interceptor.module';
import { AdminPrimeModule } from '@app/prime/admin.prime.module';

@NgModule({
  declarations: [
    AdminComponent,
    DevicesRegisteredComponent,
    FormDeviceComponent,
    ShortDescriptionPipe
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    AdminMaterialModule,
    AdminPrimeModule,
    InterceptorModule
  ]
})
export class AdminModule { }
