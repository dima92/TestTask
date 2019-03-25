import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order.service';
import { Order } from '../models/order';


@Component({
    selector: 'app-order',
    templateUrl: './order.component.html'
})
export class OrderComponent implements OnInit {

    order: Order = new Order();
    orders: Order[];

    constructor(private orderService: OrderService) {
    }



    ngOnInit() {
        this.orderService.getOrders().subscribe((data: Order[]) => {
            this.orders = data;
        },

            error => {
                alert(error.error.Message);
                //for (var i = 0; i < error.error.ModelState.errorLogin.length; i++) {
                //    alert(error.error.ModelState.errorLogin[i]);
                //}
            });


        this.orderService.createOrder(this.order).subscribe((data: Order) => {
            this.orders.push(data);
        });



        this.orderService.updateOrder(this.order).subscribe(data => this.order);

        this.orderService.deleteOrder(this.order.id).subscribe(data => this.order);

    }
}


