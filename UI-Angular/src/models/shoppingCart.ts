

export class ShoppingCart{

    id!: number;
    productId: number;
    userId: number;
    quantity: number;
    unitPrice: number;
    totalPrice: number;

    constructor(productId: number, quantity: number, 
    unitPrice: number, totalPrice: number, userId: number){
        this.productId = productId;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
        this.totalPrice = totalPrice;
        this.userId = userId;
    }

}