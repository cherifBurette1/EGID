import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarketListComponent } from './market-list/market-list.component';
import { OrderComponent } from './order/order.component';
import { OrdersListComponent } from './orders-list/orders-list.component';

const routes: Routes = [
  {path:'',component: MarketListComponent},
  {path:'market-screen',component: MarketListComponent},
  {path:'orders-screen',component:OrdersListComponent},
  { path: 'order/:id/:name/:price', component: OrderComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingModule = [MarketListComponent,OrdersListComponent]