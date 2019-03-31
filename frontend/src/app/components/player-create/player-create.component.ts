import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Player } from '../../models/player';
import { PlayerService } from 'src/app/services/player.service';
import { SkillLevelService } from 'src/app/services/skill-level.services';
import { SkillLevel } from '../../models/skilllevel';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-player-create',
  templateUrl: './player-create.component.html'
})
export class PlayerCreateComponent implements OnInit {
  playerForm: FormGroup;
  submitted = false;
  isUpdate = false;
  options: any = [];

  @Output() playerCreated = new EventEmitter<boolean>();

  constructor(
    private playerService: PlayerService,
    private skillService: SkillLevelService,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.playerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      skill: ['', Validators.required],
      age: [''],
      emailAddress: ['', [Validators.required, Validators.email]],
      id: ['']
    });
    this.getSkillLevels();
  }

  getSkillLevels(){
    this.skillService.getSkillLevels().subscribe((skills: SkillLevel[]) => {
      for(let i=0,j=skills.length;i<j;i++){
        this.options.push({
          value: skills[i].Id, text: skills[i].Name, selected: false
        });
      }
    });
  }

  get f() {
    return this.playerForm.controls;
  }

  onCreate() {
    this.submitted = true;

    if (this.playerForm.invalid) {
      return;
    }

    const formValues = this.playerForm.value;
    const player: Player = new Player(formValues['firstName'],formValues['lastName'],formValues['skill'],formValues['age'],formValues['emailAddress']);

    this.playerService
      .createPlayer(player)
      .subscribe((players: Player[]) => {
        this.playerCreated.emit(true);
        this.playerForm.reset();
        this.setSnackBar('The player was created successfully.');
      });
  }

  onUpdate() {
    const formValues = this.playerForm.value;
    const player: Player = new Player(formValues['firstName'],formValues['lastName'],formValues['skill'],formValues['age'],formValues['emailAddress'],formValues['id']);
    this.playerService.updateItem(player).subscribe((result) => {
      this.playerCreated.emit(true);
      this.playerForm.reset();
      this.setSnackBar('The player was updated successfully.');
      this.isUpdate = false;
    });
  }

  cancelForm() {
    this.isUpdate = false;
    this.playerForm.reset();
  }

  setUpdate($event) {
    this.isUpdate = true;
    console.log($event);
    const player: Player = $event;

    this.playerForm.reset();

    this.playerForm.setValue({
      id: player.Id,
      firstName: player.FirstName,
      lastName: player.LastName,
      emailAddress: player.Email,
      skill: player.SkillLevelId,
      age: player.Age
    });
  }

  setSnackBar(message: string){
    this.snackBar.open(message, 'Close', {duration: 5000});
  }
}
