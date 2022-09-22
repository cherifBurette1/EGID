export class StockModel {
    public id ;
    public name = '';
    public price = 1.0;
    constructor() {}
  
    AddData(id: number, name: string, price: number) {
      this.id = id;
      this.name = name;
      this.price = price;
    }
  }