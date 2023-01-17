

export class RegisteredUser{
    id!: number;
    firstName: string;
    lastName: string;
    userName: string;
    password: string;
    email: string;
    role: RegisteredUserRole;
    phone: string;
    address: string;
    orderIds: Array<Number>;
    shoppingCartItemIds: Array<Number>;
    reviewIds: Array<Number>;
    
    constructor(firstName: string, lastName: string, userName: string, password: string, 
        email: string, role: RegisteredUserRole, phone: string, address: string, 
        orderIds: Array<Number>, shoppingCartItemIds: Array<Number>, reviewIds: Array<Number>){
            this.firstName = firstName,
            this.lastName = lastName,
            this.userName = userName,
            this.password = password,
            this.email = email,
            this.role = role,
            this.phone = phone,
            this.address = address,
            this.orderIds = orderIds,
            this.shoppingCartItemIds = shoppingCartItemIds,
            this.reviewIds = reviewIds;
        }



}

export enum RegisteredUserRole{
    RegisteredUser,
    WaterPointRepresentative,
    Admin
}