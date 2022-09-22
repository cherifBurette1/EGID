import { Component, OnInit } from '@angular/core';
import { OrderService } from '../shared/services/order.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
