import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImportationsComponent } from './components/importations/importations.component';

const routes: Routes = [
  { path: '/', component: ImportationsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }