import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';


@Component({
    selector: 'app-user',
    templateUrl: './user.component.html'
})
export class UserComponent implements OnInit {

    user: User = new User();
    users: User[];

    constructor(private userService: UserService) {
    }



    ngOnInit() {
        this.userService.getUsers().subscribe((data: User[]) => {
            this.users = data;
        },

            error => {
                for (var i = 0; i < error.error.error.length; i++) {
                    alert(error.error.error[i]);
                }
            });


        //this.userService.createUser(this.user).subscribe((data: User) => {
        //    this.users.push(data);
        //});



        this.userService.updateUser(this.user).subscribe(data => this.user);

        this.userService.deleteUser(this.user.id).subscribe(data => this.user);

    }
}


