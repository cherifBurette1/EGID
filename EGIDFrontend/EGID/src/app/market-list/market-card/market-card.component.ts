import { Component, NgZone, OnInit } from '@angular/core';
import { StockModel } from 'src/app/shared/models/stock.model';
import { SignalRService } from 'src/app/shared/services/signal-r.service';
import { ActivatedRoute, Router} from '@angular/router';
@Component({
  selector: 'app-market-card',
  templateUrl: './market-card.component.html',
  providers: [SignalRService],
  styleUrls: ['./market-card.component.scss']
})
export class MarketCardComponent implements OnInit {
  stocks = new Array<StockModel>();
  stock = new StockModel;
      // tslint:disable-next-line:variable-name
    constructor(
      public signalRService: SignalRService,
      private _ngZone: NgZone,
      private router: Router,
    ) {
    }
    ngOnInit(): void {
        this.signalRService.startConnection();
        try{
          this.signalRService.askServer();
          this.signalRService.askServerListener();
          this.subscribeToEvents();
    }
        catch{(err: any)=> console.log(err)};
      }
      private subscribeToEvents(): void {

        this.signalRService.stocksReceived.subscribe((message: Array<StockModel>) => {
          this._ngZone.run(() => {  
              message.forEach(element => {
                if(this.stocks.length >= message.length){
                this.stocks = new Array<StockModel>();
                }
                this.stocks.push(element);
              });
            });
          });
        }
      public BuyNow( stock: StockModel): void {
        this.router.navigate(['/order', stock.id,stock.name,stock.price]);
      }
      ngOnDestroy(): void {
        this.signalRService.hubConnection.off("connection off");
      }
    }