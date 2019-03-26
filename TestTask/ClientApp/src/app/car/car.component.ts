import { Component, OnInit } from '@angular/core';
import { CarService } from '../services/car.service';
import { Car } from '../models/car';


@Component({
    selector: 'app-car',
    templateUrl: './car.component.html'
})
export class CarComponent implements OnInit {

    car: Car = new Car();
    cars: Car[];

    constructor(private carService: CarService) {
    }

    ngOnInit() {
        this.carService.getCars().subscribe((data: Car[]) => {
            this.cars = data;
        },

            error => {
                for (var i = 0; i < error.error.error.length; i++) {
                    alert(error.error.error[i]);
                }
            });
    }
}


