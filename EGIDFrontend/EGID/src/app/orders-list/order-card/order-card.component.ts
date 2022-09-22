import { Component, OnInit } from '@angular/core';
import { OrderListModel } from 'src/app/shared/models/order-list.model';
import { OrderService } from 'src/app/shared/services/order.service';

@Component({
  selector: 'app-order-card',
  templateUrl: './order-card.component.html',
  styleUrls: ['./order-card.component.scss']
})
export class OrderCardComponent implements OnInit {
  orders: OrderListModel[];
  constructor(public service: OrderService) { }

  ngOnInit(): void {
    this.service.GetOrders();
    this.orders = this.service.globalOrdersList;
  }

}
