import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { map, Observable } from 'rxjs';
import { BrokerModel } from '../models/broker.model';
import { OrderListModel } from '../models/order-list.model';
import { PersonModel } from '../models/person.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  globalBrokerList: BrokerModel[] = [];
  globalPersonList: PersonModel[] = [];
  globalOrdersList: OrderListModel[] = [];
  readonly rootURL ="http://localhost:5001/"
  constructor(private http : HttpClient, private toaster: ToastrService) { }
  AddOrder(stockId : number,brokerId : number, personId : number ,price: number, stockName: string){
    debugger;
    if(brokerId == 0){
      this.toaster.warning('please add broker');
    }
    else{
    var data = {
      "id":stockId,
      "brokerId": !(brokerId == 0)? Number(brokerId): null,
      "personId": Number(personId),
      "price": price,
    }
   this.http.post(`${this.rootURL}order`, data
           ).subscribe();
    }
  }


    GetBrokers(){
      this.GetBrokersObs().subscribe((data: BrokerModel[]) => {
        
        //this.globalBrokerList.push(new BrokerModel())= data[0];
        for(let i=0;i< data.length;i++)
        {
          var temp = new BrokerModel(data[i].id, data[i].name);
         this.globalBrokerList.push(temp);
         console.log(this.globalBrokerList);
        }
              });
}
      GetBrokersObs(): Observable<BrokerModel[]> {
        return this.http.get<BrokerModel[]>(`${this.rootURL}brokers`)
}
GetOrders(){
  this.GetOrdersObs().subscribe((data: OrderListModel[]) => {
    
    //this.globalBrokerList.push(new BrokerModel())= data[0];
    for(let i=0;i< data.length;i++)
    {
      var temp = new OrderListModel(data[i].id, data[i].brokerName, data[i].personName, data[i].price, data[i].commission, data[i].quantity);
     this.globalOrdersList.push(temp);
     console.log(this.globalOrdersList);
    }
          });
}
  GetOrdersObs(): Observable<OrderListModel[]> {
    return this.http.get<OrderListModel[]>(`${this.rootURL}orders`)
}
GetPersons(){
  this.GetPersonsObs().subscribe((data: PersonModel[]) => {
    debugger;
    //this.globalBrokerList.push(new BrokerModel())= data[0];
    for(let i=0;i< data.length;i++)
    {
      var temp = new PersonModel(data[i].id, data[i].name);
     this.globalPersonList.push(temp);
     console.log(this.globalPersonList);
    }
    console.log(this.globalPersonList);
        });
}
  GetPersonsObs(): Observable<PersonModel[]> {
    return this.http.get<PersonModel[]>(`${this.rootURL}person`)
}
}
