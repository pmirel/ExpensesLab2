import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpensesEditComponent } from './expenses-edit/expenses-edit.component';
import { ExpensesListComponent } from './expenses-list/expenses-list.component';
import { ExpensesComponent } from './expenses.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    {
        path: '', component: ExpensesComponent,
        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: ExpensesListComponent },
            { path: 'edit/:id', component: ExpensesEditComponent },
            { path: 'edit', component: ExpensesEditComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ExpensesRoutingModule {
    static routedComponents = [ExpensesComponent, ExpensesListComponent, ExpensesEditComponent];
}
