

export class ShoppingCart{

    id!: number;
    productId: number;
    quantity: number;
    unitPrice: number;
    totalPrice: number;

    constructor(productId: number, quantity: number, 
    unitPrice: number, totalPrice: number){
        this.productId = productId;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        this.totalPrice = totalPrice;
    }

}