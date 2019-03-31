import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Player } from '../../models/player';
import { MatTableDataSource } from '@angular/material';
import { PlayerService } from 'src/app/services/player.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: "app-player-manager",
  templateUrl: "./player-manager.component.html"
})
export class PlayerManagerComponent implements OnInit {
  displayedColumns: string[] = [
    "firstName",
    "lastName",
    "skill",
    "age",
    "emailAddress",
    "actions"
  ];

  playerDataSources = new MatTableDataSource<Player>();

  @Output() updatePlayer = new EventEmitter<Player>();

  constructor(private playerService: PlayerService, private snackBar: MatSnackBar) {}

  ngOnInit() {
    this.getPlayers();
  }

  getPlayers() {
    this.playerService.getPlayers().subscribe((players: Player[]) => {
      console.log(players);
      this.playerDataSources.data = players;
    });
  }

  updateItem(_id: number) {
    const player = this.playerDataSources.data.find(player => {
      return player.Id === _id;
    });
    this.updatePlayer.emit(player);
  }

  deleteItem(_id: number) {
    this.playerService.deleteItem(_id).subscribe(data => {
      this.getPlayers();
      this.snackBar.open('This player was deleted successfully.','Close',{duration: 5000});
    });
  }

  hasData() {
    return this.playerDataSources.data.length > 0;
  }
}

