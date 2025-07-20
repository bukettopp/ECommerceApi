import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { OrderComponent } from '../order/order.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ProductsComponent
  ],
  imports: [
    CommonModule,
      RouterModule.forChild([
          { path: "",component: OrderComponent}
        ])
  ]
})
export class ProductsModule { }
