import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './Components/product/product.component';
import { ProductAdminComponent } from './Components/product-admin/product-admin.component';

const routes: Routes = [
{ path: 'products', component: ProductComponent},
{ path: 'admin/products', component: ProductAdminComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})

export class AppRoutingModule {}
