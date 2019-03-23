import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { OrderComponent } from './order/order.component';
import { UserComponent } from './user/user.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { GridModule } from '@progress/kendo-angular-grid';
import { WindowModule } from '@progress/kendo-angular-dialog';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DialogModule, WindowRef } from '@progress/kendo-angular-dialog';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { PopupModule } from '@progress/kendo-angular-popup';
import { ResizeSensorModule } from '@progress/kendo-angular-resize-sensor/dist/es2015';
import { InputsModule } from '@progress/kendo-angular-inputs';

import { TreeViewModule } from '@progress/kendo-angular-treeview';
import '@progress/kendo-angular-intl/locales/ru/all';
import { MessageService } from '@progress/kendo-angular-l10n';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { TooltipModule } from '@progress/kendo-angular-tooltip';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ChartsModule } from '@progress/kendo-angular-charts';

import { UserService } from './services/user.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        OrderComponent,
        UserComponent,
        FetchDataComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        GridModule,
        WindowModule,
        //ButtonsModule,
        //DialogModule,
        //ChartsModule,
        //DropDownsModule,
        //TooltipModule,
        //LayoutModule,
        //DateInputsModule,
        //InputsModule,
        //BrowserAnimationsModule,
        //TreeViewModule,
        //PopupModule,
        //ResizeSensorModule,
        RouterModule.forRoot([
            { path: '', component: OrderComponent, pathMatch: 'full' },
            { path: 'user', component: UserComponent },
            { path: 'fetch-data', component: FetchDataComponent },
        ])
    ],
    providers: [UserService,
     //   WindowRef, MessageService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
