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
                alert(error.error.Message);
                //for (var i = 0; i < error.error.ModelState.errorLogin.length; i++) {
                //    alert(error.error.ModelState.errorLogin[i]);
                //}
            });


        this.carService.createCar(this.car).subscribe((data: Car) => {
            this.cars.push(data);
        });



        this.carService.updateCar(this.car).subscribe(data => this.car);

        this.carService.deleteCar(this.car.id).subscribe(data => this.car);

    }
}


