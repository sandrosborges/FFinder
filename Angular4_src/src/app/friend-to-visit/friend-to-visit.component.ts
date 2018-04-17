import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Friend }         from '../Friend';
import { FriendService }  from '../Friend.service';

@Component({
  selector: 'app-friend-to-visit',
  templateUrl: './friend-to-visit.component.html',
  styleUrls: ['./friend-to-visit.component.css']
})
export class FriendToVisitComponent implements OnInit {

  friend: Friend;
  friendsNearMe:Friend[];
 
  constructor(
    private route: ActivatedRoute,
    private friendService: FriendService,
    private location: Location
  ) {}

  ngOnInit() {
    this.getFriend();    
    this.getNearFriends();
  }

  getFriend(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.friendService.getFriend(id)
      .subscribe(friend => this.friend = friend );
  }

  getNearFriends():void{

    const id = +this.route.snapshot.paramMap.get('id');
    this.friendService.getFriendNearMe(id)
      .subscribe(friendsNear => this.friendsNearMe = friendsNear);
  }

  goBack(): void {
    this.location.back();
  }




}
