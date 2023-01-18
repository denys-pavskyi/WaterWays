import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';
import { RegisteredUser } from 'src/models/registered-user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user$: Observable<RegisteredUser> | undefined;

  constructor(public accountService: AccountService){


  }
  ngOnInit(): void {
   this.user$ = this.accountService.getById(Number(window.localStorage.getItem('ID')));
  }

}
