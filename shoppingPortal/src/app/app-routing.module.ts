import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { AdminComponent } from './components/admin/admin.component';
import { HomeComponentComponent } from './components/home-component/home-component.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ProductsComponent } from './components/products/products.component';

const routes: Routes = [
  {path: 'home',component:HomeComponentComponent},
  {path: 'aboutUs',component:AboutUsComponent},
  {path: 'products',component:ProductsComponent},
  {path: 'admin',component:AdminComponent}, 
  {path: '',redirectTo: '/home', pathMatch: 'full'},
  {path:'login',component:LoginComponent},
  {path: '**',component:NotFoundComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
