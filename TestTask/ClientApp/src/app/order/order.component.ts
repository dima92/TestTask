import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';
import { UserService } from '../services/user.service';
import { CarService } from '../services/car.service';
import { Order } from '../models/order';
import { User } from '../models/user';
import { Car } from "../models/car";



@Component({
    selector: 'app-order',
    templateUrl: './order.component.html',

})
export class OrderComponent implements OnInit {

    order: Order = new Order();
    orders: Order[];
    status: boolean = true;
    allUsers: User[];
    allCars: Car[];
    orderObj: {} = {};
    filter: {} = {};
    isNew: boolean = true;

    constructor(private orderService: OrderService,
        private userService: UserService,
        private carService: CarService) {
    }



    ngOnInit() {
        this.getOrders();

        this.userService.getUsers().subscribe((data: User[]) => {
            this.allUsers = data;
        },
            error => {
                for (var i = 0; i < error.error.error.length; i++) {
                    alert(error.error.error[i]);
                }
            });

        this.carService.getCars().subscribe((data: Car[]) => {
            this.allCars = data;
        },
            error => {
                for (var i = 0; i < error.error.error.length; i++) {
                    alert(error.error.error[i]);
                }
            });
    }

    add() {
        this.orderObj = {};
        this.orderObj = {
            startDate: new Date(),
            endDate: new Date(),
        };
        this.status = false;
    }

    getOrders() {

        this.orderService.getOrders(this.filter).subscribe((data: Order[]) => {
            this.orders = data;
        },

            error => {
                for (var i = 0; i < error.error.error.length; i++) {
                    alert(error.error.error[i]);
                }
            });
    }


    addNewOrder(orderData) {
        this.orderService.createOrder(orderData).subscribe((data: Order) => {
            this.getOrders();
            this.status = true;
        });
    }
    cancel() {
        this.status = true;
        this.isNew = true;
    }

    filterForm() {
        this.getOrders();
    }

    edit(order) {
        this.status = false;
        this.isNew = false;
        this.orderObj = order;

    }

    save(order) {
        debugger;
        this.orderService.updateOrder(order).subscribe((data) => {
            this.getOrders();
            this.status = true;
        },
            error => {
                for (var i = 0; i < error.error.error.length; i++) {
                    alert(error.error.error[i]);
                }
            });
    }

    delete(id) {
        this.orderService.deleteOrder(id).subscribe(data => this.getOrders());

        error => {
            for (var i = 0; i < error.error.error.length; i++) {
                alert(error.error.error[i]);
            }
        };
    }
}


