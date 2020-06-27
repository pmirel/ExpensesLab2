import { Component, OnInit } from '@angular/core';
import { Expense } from '../expenses.models';
import { ExpensesService } from '../expenses.service';
import { PaginatedExpenses } from '../paginatedExpenses.models';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-expenses-list',
  templateUrl: './expenses-list.component.html',
  styleUrls: ['./expenses-list.component.css']
})
export class ExpensesListComponent implements OnInit {

    public displayedColumns: string[] = ['description', 'sum', 'location', 'dateAdded', 'currency', 'typeOfExpense', 'numberOfComments', 'action'];
    public expenses: PaginatedExpenses;
    public pageEvent: PageEvent;
    

    constructor(private expensesService: ExpensesService) {
    }

    ngOnInit() {
        this.loadExpenses(null);
    }

    loadExpenses(event?: PageEvent) {
        this.expenses = null;
        this.expensesService.listExpenses(event).subscribe(res => {
            this.expenses = res;
            
        });
    }

    deleteExpense(expense: Expense) {
        this.expensesService.deleteExpense(expense.id).subscribe(x => {
            this.loadExpenses();
        });
    }



}
