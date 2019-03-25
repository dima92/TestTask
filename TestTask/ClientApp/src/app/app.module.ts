import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { OrderComponent } from './order/order.component';
import { UserComponent } from './user/user.component';
import { CarComponent } from './car/car.component';

import { UserService } from './services/user.service';
import { CarService } from './services/car.service';
import { OrderService } from './services/order.service';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        OrderComponent,
        UserComponent,
        CarComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: OrderComponent, pathMatch: 'full' },
            { path: 'user', component: UserComponent },
            { path: 'car', component: CarComponent },
        ])
    ],
    providers: [UserService,
        CarService,
        OrderService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
