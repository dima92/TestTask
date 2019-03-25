import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Car } from '../models/car';


@Injectable()
export class CarService {

    private url = "/api/cars";

    constructor(private http: HttpClient) {
    }

    getCars() {
        return this.http.get(this.url);
    }

    createCar(car: Car) {
        return this.http.post(this.url, car);
    }
    updateCar(car: Car) {

        return this.http.put(this.url + '/' + car.id, car);
    }
    deleteCar(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}