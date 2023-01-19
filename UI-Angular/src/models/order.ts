

export class Order{

    id!: number;
    orderText: string;
    userId: number;
    orderDate: Date;
    contactPhone: string;
    address: string;
    totalPrice: number;
    isToBeDelivered: boolean;
    orderStatus: OrderStatus;
    orderDetailIds: Array<number>;


    constructor(orderText: string, userId: number, orderDate: Date, contactPhone: string, 
    address: string, totalPrice: number, isToBeDelivered: boolean, 
    orderStatus: OrderStatus, orderDetailIds: Array<number>){

        this.orderText = orderText;
        this.userId = userId;
        this.orderDate = orderDate;
        this.contactPhone = contactPhone;
        this.address = address;
        this.totalPrice = totalPrice;
        this.isToBeDelivered = isToBeDelivered;
        this.orderStatus = orderStatus;
        this.orderDetailIds = orderDetailIds;
    }

}


export enum OrderStatus{
    Done,
    InProgress,
    Canceled,
    OnDelivery
}