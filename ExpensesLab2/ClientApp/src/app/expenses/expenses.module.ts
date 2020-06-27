import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { ExpensesRoutingModule } from './expenses-routing.module';
import { ExpensesService } from './expenses.service'



@NgModule({
    declarations: [ExpensesRoutingModule.routedComponents],
  imports: [
      CommonModule,
      ExpensesRoutingModule,
      AngularMaterialModule,
      CoreModule,
      FormsModule,
      ReactiveFormsModule
    ],
    providers: [ExpensesService],
})
export class ExpensesModule { }
