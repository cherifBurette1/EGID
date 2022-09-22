import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrderService } from '../shared/services/order.service';
import { ToastrService } from 'ngx-toastr';
import { PersonModel } from '../shared/models/person.model';
import { BrokerModel } from '../shared/models/broker.model';
import { Router,ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit, OnDestroy {

  constructor(public service: OrderService, private toastr: ToastrService,private route: ActivatedRoute, private router: Router) { }
person: PersonModel[];
broker: BrokerModel[];
brokr: number = 0;
persn: number= 0; 
id: number;
price: number;
stockName: string;
async ngOnInit() {
  this.id = Number(this.route.snapshot.paramMap.get('id'));
  this.price = Number(this.route.snapshot.paramMap.get('price'));
  this.stockName = this.route.snapshot.paramMap.get('name');;
    this.service.GetBrokers();
    this.broker = this.service.globalBrokerList;
    this.service.GetPersons();
    this.person = this.service.globalPersonList;
  }
    InsertRecord() {
      this.service.AddOrder(this.id,this.brokr,this.persn,this.price,this.stockName)
        debugger;
      if(this.brokr != 0){
        this.brokr = 0;
        this.persn = 0;
        this.router.navigate(['orders-screen']);
      };
}
ngOnDestroy(): void {
  debugger;
  this.brokr = 0;
  this.persn = 0;
}
}
