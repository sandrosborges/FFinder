import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FriendsComponent } from './friends/friends.component';
import { FriendToVisitComponent } from './friend-to-visit/friend-to-visit.component';



const routes: Routes = [
  { path: '', redirectTo: '/Friends', pathMatch: 'full' },
  { path: 'Friends', component: FriendsComponent },
  { path: 'Friends2Visit/:id', component: FriendToVisitComponent }  
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule { }
