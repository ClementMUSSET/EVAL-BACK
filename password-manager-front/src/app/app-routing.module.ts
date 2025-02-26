import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PasswordListComponent } from './components/password-list/password-list.component';
import { AddPasswordComponent } from './components/add-password/add-password.component';

export const routes: Routes = [
  { path: '', redirectTo: '/passwords', pathMatch: 'full' },
  { path: 'passwords', component: PasswordListComponent },
  { path: 'add-password', component: AddPasswordComponent },
  // Redirection pour pages inexistantes
  { path: '**', redirectTo: '/passwords' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


