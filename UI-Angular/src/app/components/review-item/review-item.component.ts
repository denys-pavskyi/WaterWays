import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';
import { RegisteredUser } from 'src/models/registered-user';
import { Review } from 'src/models/review';

@Component({
  selector: 'app-review-item',
  templateUrl: './review-item.component.html',
  styleUrls: ['./review-item.component.css']
})
export class ReviewItemComponent implements OnInit {

  @Input()review! : Review;

  user$!: Observable<RegisteredUser> | undefined;

  constructor(public accountService: AccountService){

  }

  ngOnInit(): void {
    this.user$ = this.accountService.getById(this.review.userId);
  }

}
