import { Component, OnInit } from '@angular/core';
import { Citizen } from '../../../models/citizen';
import { Observable } from 'rxjs';
import { CitizenService } from '../../../services/citizen.service';
import { MatTableModule } from '@angular/material';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-citizenlist',
  templateUrl: './citizenlist.component.html',
  styleUrls: ['./citizenlist.component.scss']
})

export class CitizenlistComponent implements OnInit {

  public citizenlist= new MatTableDataSource<Citizen>();
  public displayedColumns: string[] = ['CitizenID', 'AMKA', 'AFM', 'Onoma', 'Eponimo', 'Actions'];
    constructor(private citizenService: CitizenService) {
  
  }

  ngOnInit() {
    this.citizenService.getCitizens()
      .subscribe(data => {
        console.log(data);
        this.citizenlist.data = data;
      });
    
  }

 

}
