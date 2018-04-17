import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FriendService }          from './Friend.service';


import { AppComponent } from './app.component';
import { FriendsComponent } from './friends/friends.component';
import { AppRoutingModule } from './app-routing.module';
import { FriendToVisitComponent } from './friend-to-visit/friend-to-visit.component';

import { HttpClientModule, HttpClient } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    FriendsComponent,
    FriendToVisitComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [ FriendService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
