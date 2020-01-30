import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatCard, MatCardTitle } from '@angular/material';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user';
import { Router } from '@angular/router';
import { Citizen } from '../../../models/citizen';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerform: FormGroup = new FormGroup({
    firstname: new FormControl(''),
    lastname: new FormControl(''),
    mobile: new FormControl(''),
    email: new FormControl(''),
    login: new FormControl(''),
    password: new FormControl(''),
    password2: new FormControl('')
  });


  constructor(private authService: AuthService, private router: Router ) { }

  ngOnInit() {
  }

  register() {
    let tuser = new Citizen();
    tuser.citizenid = 0;
    tuser.amka = '';
    tuser.afm = '';
    tuser.onoma = this.registerform.get('firstname').value;
    tuser.eponimo = this.registerform.get('lastname').value;
    tuser.patronimo = '';
    tuser.mitronimo = '';
    tuser.hmerominiaGenisis = null;
    tuser.poliGenisis = '';
    tuser.tilefono = '';
    tuser.kinito = this.registerform.get('mobile').value;
    tuser.eMail = this.registerform.get('email').value;
    tuser.login = this.registerform.get('login').value;
    tuser.password = this.registerform.get('password').value;
    if (this.registerform.valid) {
      this.authService.register(tuser).subscribe(
        (response) => {
          console.log(response);
          this.router.navigate(['login']);
        }
      )
    }
  }

}
