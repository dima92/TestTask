import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order';


@Injectable()
export class OrderService {

    private url = "/api/orders";

    constructor(private http: HttpClient) {
    }

    getOrders(filter: any) {
        let param = this.url + "?avto=" + (filter.avto == undefined ? '' : filter.avto) + "&startDate="
            + (filter.startDate == undefined ? '' : filter.startDate.toLocaleDateString()) + "&endDate="
            + (filter.endDate == undefined ? '' : filter.endDate.toLocaleDateString()) + "&user="
            + (filter.user == undefined ? '' : filter.user);
        return this.http.get(param);
    }

    createOrder(order: Order) {
        return this.http.post(this.url, order);
    }
    updateOrder(order: Order) {

        return this.http.put(this.url + '/' + order.id, order);
    }
    deleteOrder(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}