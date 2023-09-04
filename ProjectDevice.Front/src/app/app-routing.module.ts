import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DevicesPrincipalScreenComponent } from './views/pages/devices-principal-screen/devices-principal-screen.component';
import { TestFileComponent } from './views/pages/test-file/test-file.component';

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
    path: 'test-files',
    component:  TestFileComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
