import { Component, OnInit } from '@angular/core';
import { Expense } from '../expenses.models';
import { ExpensesService } from '../expenses.service';

@Component({
  selector: 'app-expenses-list',
  templateUrl: './expenses-list.component.html',
  styleUrls: ['./expenses-list.component.css']
})
export class ExpensesListComponent implements OnInit {

    public displayedColumns: string[] = ['description', 'sum', 'location', 'dateAdded', 'currency', 'typeOfExpense', 'numberOfComments', 'action'];
    public expenses: Expense[];
    

    constructor(private expensesService: ExpensesService) {
    }

    ngOnInit() {
        this.loadExpenses();
    }

    loadExpenses() {
        this.expensesService.listExpenses().subscribe(res => {
            this.expenses = res;
            
        });
    }

    deleteExpense(expense: Expense) {
        this.expensesService.deleteExpense(expense.id).subscribe(x => {
            this.loadExpenses();
        });
    }



}
