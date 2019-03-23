import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
//import { User } from '../models/user';
//import { State } from '@progress/kendo-data-query';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html'
})
export class UserComponent implements OnInit {
    //@ViewChild('grid')
    //animate: false;
    //public gridData: Array<any> = [];
    //loading: boolean = false;

    constructor(private userService: UserService) {
    }

    //public state: State = {
    //    skip: 0,
    //    take: 5,

        // Initial filter descriptor
        //filter: {
        //    logic: 'and',
        //    filters: [{ field: 'CategoryDescription', operator: 'contains', value: 'Chef' }]
        //}
  //  };

    ngOnInit(): void {
        //this.loading = true;
        //this.userService.getUsers().subscribe((result: any) => {
        //    this.gridData = result;
        //    this.loading = false;
        //    },
        //    error => {
        //        alert(error.error.Message);
        //        for (var i = 0; i < error.error.ModelState.errorLogin.length; i++) {
        //            alert(error.error.ModelState.errorLogin[i]);
        //        }
        //    });
    }
}


