

export class Review{
    id!: number;
    waterPointId: number;
    userId: number;
    rating: number;
    uploadedOn: Date;
    reviewText: string;

    constructor(waterPointId: number, userId: number, 
    rating: number,uploadedOn: Date, reviewText: string){
        this.waterPointId = waterPointId;
        this.userId = userId;
        this.rating = rating;
        this.uploadedOn = uploadedOn;
        this.reviewText = reviewText;
    }

}