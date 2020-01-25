import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatCard, MatCardTitle } from '@angular/material';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  loginform: FormGroup = new FormGroup({
    login: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private authService: AuthService, private router: Router  ) { }


  authenticate() {
    let tuser = new User();
    tuser.login = 'admin';
    tuser.login = this.loginform.get('login').value;
    tuser.password = this.loginform.get('password').value;
    if (this.loginform.valid) {
      this.authService.authenticate(tuser).subscribe(
        (response) => {
          console.log(response);
          this.router.navigate(['home']);
        }
      )
    }
  }

  

  ngOnInit() {
  }


}
