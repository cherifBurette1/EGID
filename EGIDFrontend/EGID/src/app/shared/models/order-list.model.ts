export class OrderListModel {
    id: number ;
    brokerName: string;
    personName: string;
    price: number;
    commission: number;
    quantity: number;
    constructor(id: number, brokername: string, personname: string, price: number, commission: number, quantity: number) {
        this.id = id;
        this.brokerName = brokername;
        this.personName = personname;
        this.price = price;
        this.commission = commission;
        this.quantity = quantity;
      }
}