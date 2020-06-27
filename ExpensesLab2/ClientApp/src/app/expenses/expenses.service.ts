import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Expense } from './expenses.models';
import { ApplicationService } from '../core/services/application.service';
import { PaginatedExpenses } from './paginatedExpenses.models';
import { PageEvent } from '@angular/material/paginator';
//import { PaginatedExpenses } from './paginatedExpenses.models';
//import { PageEvent } from '@angular/material/paginator';

@Injectable()
export class ExpensesService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getExpense(id: number) {
        return this.http.get<Expense>(`${this.applicationService.baseUrl}api/Expenses/${id}`);
    }

    listExpenses(event?: PageEvent) {
        let pageIndex = event ? event.pageIndex + "" : "0";
        let itemsPerPage = event ? event.pageSize + "" : "25";
        console.log(event);
        let params = new HttpParams().set("page", pageIndex).set("itemsPerPage", itemsPerPage); //Create new HttpParams
        return this.http.get<PaginatedExpenses>(`${this.applicationService.baseUrl}api/Expenses`, { params: params });
    }

    saveExpense(expense: Expense) {
        return this.http.post(`${this.applicationService.baseUrl}api/Expenses`, expense);
    }

    modifyExpense(expense: Expense) {
        return this.http.put(`${this.applicationService.baseUrl}api/Expenses/${expense.id}`, expense);
    }

    deleteExpense(id: number) {
        return this.http.delete<any>(`${this.applicationService.baseUrl}api/Expenses/${id}`);
    }
}
