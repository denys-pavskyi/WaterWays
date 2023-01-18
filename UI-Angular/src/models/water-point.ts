

export class WaterPoint{

    id!: number;
    title: string;
    description: string;
    waterPointType: WaterPointType;
    phoneNumber: string;
    address: string;
    rating: number;
    isVerified: boolean;
    hasOrdering: boolean;
    hasOwnDelivery: boolean;
    hasSearchPriority: boolean;
    userId: number;
    verificationDocumentId!: number;
    photoUrl: string;

    reviewIds: Array<number>;
    productIds: Array<number>;

    constructor(title: string, description: string, waterPointType: WaterPointType, 
    phoneNumber: string, address: string, rating: number, isVerified: boolean, 
    hasOrdering: boolean, hasOwnDelivery: boolean, hasSearchPriority: boolean, 
    userId: number, verificationDocumentId: number, 
    reviewIds: Array<number>, productIds: Array<number>, photoUrl: string){
        this.title = title;
        this.description = description;
        this.waterPointType = waterPointType;
        this.phoneNumber = phoneNumber;
        this.address = address;
        this.rating = rating;
        this.isVerified = isVerified;
        this.hasOrdering = hasOrdering;
        this.hasOwnDelivery = hasOwnDelivery;
        this.userId = userId;
        this.hasSearchPriority = hasSearchPriority;
        this.reviewIds = reviewIds;
        this.productIds = productIds;
        this.photoUrl = photoUrl;
        this.verificationDocumentId = verificationDocumentId;
    }
}

export enum WaterPointType{
    PumpStation,
    WaterDelivery,
    Shop,
    EmergencyWaterTransportation,
    Other
}