import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

/* Manage all Angular Material used modules */
import { AngularMaterialModule } from './angular-material.module';

/* Routing */
import { AppRoutingModule } from './app-routing.module';

/* Services */
import { PlayerService } from './services/player.service';

/* Components */
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { PlayerManagerComponent } from './components/player-manager/player-manager.component';
import { PlayerCreateComponent } from './components/player-create/player-create.component';
import { SkillLevelService } from './services/skill-level.services';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PlayerManagerComponent,
    PlayerCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [PlayerService, SkillLevelService],
  bootstrap: [AppComponent]
})
export class AppModule {}
