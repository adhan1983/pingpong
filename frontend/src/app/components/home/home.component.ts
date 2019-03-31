import { Component, OnInit } from '@angular/core';
// import { PlayerManager } from '../player-manager/player-manager.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() {}

  ngOnInit() {}

  onPlayerCreated($event) {
    console.log($event);
  }
}
