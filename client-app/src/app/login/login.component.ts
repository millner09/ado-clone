import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';
import { User } from '../user';
import { Login } from '../login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private accountService: AccountService) {}
  user: User | null = null;
  loggedIn: boolean = false;

  ngOnInit(): void {
    this.loginUser();
  }

  loginUser() {
    this.accountService.currentUser$.subscribe((user) => {
      this.loggedIn = !!user;

      if (!this.loggedIn) {
        const login: Login = {
          email: 'adam.millner@gmail.com',
          password: 'Pa$$w0rd',
        };

        this.accountService.login(login).subscribe((result) => {
          this.user = result;
          console.log(result);
        });
      } else {
        this.user = user;
      }
    });
  }
}
