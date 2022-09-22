import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule, routingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './shared/nav-bar/nav-bar.component';
import { MarketListComponent } from './market-list/market-list.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { MarketCardComponent } from './market-list/market-card/market-card.component';
import { HttpClientModule } from  '@angular/common/http';
import { OrderComponent } from './order/order.component';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { OrderCardComponent } from './orders-list/order-card/order-card.component';

@NgModule({
  declarations: [
    AppComponent,
    MarketListComponent,
    NavBarComponent,
    routingModule,
    OrdersListComponent,
    MarketCardComponent,
    OrderComponent,
    OrderCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
