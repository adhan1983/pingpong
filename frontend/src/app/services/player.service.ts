import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Player } from '../models/player';
import { of, Observable } from 'rxjs';

import { API_URL } from '../api-config';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  constructor(private http: HttpClient) {}

  pingPongPlayers: Player[] = [
  ];

  getPlayers() {
    return this.http.get(API_URL+'/players');
  }

  updateItem(player: Player) {
    return this.http.put(API_URL+'/players',player);
  }

  deleteItem(_id: number) {
    return this.http.delete(API_URL+'/players/'+_id);
  }

  createPlayer(player: Player) {
    return this.http.post(API_URL+'/players',player);
  }

  getPlayer(_id: number) {
    // return pingPongPlayers.find(items => {
    //   return items.id === _id;
    // });
  }
}