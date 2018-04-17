import { Component, OnInit } from '@angular/core';
import { Friend } from '../Friend';
import { FriendService } from '../Friend.service';



@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {

  friends:Friend[];

  constructor(private friendService: FriendService) { }

  ngOnInit() {
    this.getFriends();
  }

  getFriends(): void {
     this.friendService.getFriends()
      .subscribe(friends => this.friends = friends);
  }


}
