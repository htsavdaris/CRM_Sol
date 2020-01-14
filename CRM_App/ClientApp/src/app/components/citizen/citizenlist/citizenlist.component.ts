import { Component, OnInit } from '@angular/core';
import { Citizen } from '../../../models/citizen';
import { Observable } from 'rxjs';
import { CitizenService } from '../../../services/citizen.service';

@Component({
  selector: 'app-citizenlist',
  templateUrl: './citizenlist.component.html',
  styleUrls: ['./citizenlist.component.scss']
})
export class CitizenlistComponent implements OnInit {
  citizenlist$: Observable<Citizen[]>;


  constructor(private citizenService: CitizenService) {

  }

  ngOnInit() {
  }

  loadCitizens() {

  }

}
