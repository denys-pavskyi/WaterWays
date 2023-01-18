

export class Product{
    id!: number;
    title: string;
    description: string;
    type: ProductType;
    waterPointId: number;
    price: number;
    quantityAvailable: number;
    photoUrl: string;

    constructor(title: string, description: string, type: ProductType, 
    waterPointId: number, price: number, quantityAvailable: number, photoUrl: string){
        this.title = title;
        this.description = description;
        this.type = type;
        this.waterPointId = waterPointId;
        this.price = price;
        this.quantityAvailable = quantityAvailable;
        this.photoUrl = photoUrl;
    }
}

export enum ProductType{
        StillWater,
        SparklingWater,
        IndustrialWater,
        Other
}