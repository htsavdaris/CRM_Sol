import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CitizenService } from './services/citizen.service'
import { ForeasService } from './services/foreas.service';
import { CitizenlistComponent } from './components/citizen/citizenlist/citizenlist.component';
import { ForeaslistComponent } from './components/foreas/foreaslist/foreaslist.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { NavigationBarComponent } from './components/nav/navigation-bar/navigation-bar.component';
import { NavComponent } from './components/nav/nav/nav.component'

@NgModule({
  declarations: [
    AppComponent,
    CitizenlistComponent,
    ForeaslistComponent,
    LoginComponent,
    RegisterComponent,
    NavigationBarComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    FlexLayoutModule ,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AngularMaterialModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
