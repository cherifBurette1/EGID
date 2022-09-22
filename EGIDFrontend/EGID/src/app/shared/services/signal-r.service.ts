import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { StockModel } from '../models/stock.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  stocksReceived = new EventEmitter<StockModel>();
  connectionEstablished = new EventEmitter<Boolean>();
  constructor() {
  }
  hubConnection!: signalR.HubConnection ;
  private thenable!: Promise<void>;

    startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5002/Stock",{
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();
      this.thenable = this.hubConnection
      .start();
      this.thenable
      .then(() => {
        console.log('Hub connection started');
      })
      .catch(err => {
        console.log(`Error while establishing connection, retrying...${err}`);
      });}
  askServer(): void {
    this.thenable.then(() =>{
    this.hubConnection.invoke('GetStocks');
    }).catch((e) => console.log(e));
}   
  askServerListener(): void {
    this.hubConnection.on('GetStocksResponse', (data: any) => {
      this.stocksReceived.emit(data);
      console.log(data);
    });
  }
}