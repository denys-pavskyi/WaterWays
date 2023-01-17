

export class OrderDetail{
    id!: number;
    orderId: number;
    productId: number;
    quantity: number;
    unitPrice: number;
    totalPrice: number;

    constructor(orderId: number, productId: number, quantity: number, 
    unitPrice: number, totalPrice: number){
        this.orderId = orderId;
        this.productId = productId;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        this.totalPrice = totalPrice;
    }

}