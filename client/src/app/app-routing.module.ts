import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImportationsComponent } from './components/importations/importations.component';
import { IportationDetailsComponent } from './components/iportation-details/iportation-details.component'

const routes: Routes = [
  { path: '', component: ImportationsComponent },
  { path: 'importations/:id', component: IportationDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
