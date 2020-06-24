using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpensesLab2.Models;
using System.Runtime.InteropServices.WindowsRuntime;
using ExpensesLab2.ViewModel;

namespace ExpensesLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpensesDbContext _context;

        public ExpensesController(ExpensesDbContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        /// <summary>
        /// Get a list of all the expenses
        /// </summary>
        /// <param name="from">Filter expenses from a specific date. Leave empty for displaying all.</param>
        /// <param name="to">Filter expenses to a specific date. Leave empty for displaying all.</param>
        /// <param name="typeOfExpense">Filter expenses by a specific type. Leave empty for displaying all.</param>
        /// <returns>Alist of all the expenses</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpensesWithNumberOfComments>>> GetExpenses(
            DateTimeOffset? from = null,
            DateTimeOffset? to = null,
            [FromQuery]Models.TypeOfExpense? typeOfExpense = null)
        {
            IQueryable<Expense> result = _context.Expenses;

            if (from != null)
            {
                result = result.Where(f => from <= f.DateAdded);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }
            if (typeOfExpense != null)
            {
                result = result.Where(f => f.TypeOfExpense == typeOfExpense);
            }
            var resultList = await result
                .Select(f => new ExpensesWithNumberOfComments {
                    Id = f.Id,
                    Description = f.Description,
                    Sum = f.Sum,
                    DateAdded = f.DateAdded,
                    Currency = f.Currency,
                    TypeOfExpense = f.TypeOfExpense,
                    NumberOfComments = f.Comments.Count
                })
                .ToListAsync();
            return resultList;
                
        }

        // GET: api/Expenses/5
        /// <summary>
        /// Get a detail view of a specific expense
        /// </summary>
        /// <param name="id">Specify the id of expense you wanna see the detail</param>
        /// <returns>A detail view of a specific expense</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDetail>> GetExpense(long id)
        {
            var expense = await _context
                .Expenses
                .Include(e => e.Comments)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            return ExpenseDetail.FromExpense(expense);
        }

        // PUT: api/Expenses/5
        /// <summary>
        /// Update a specific expense
        /// </summary>
        /// <param name="id"></param>
        /// <param name="expense">The name of the expense</param>
        /// <returns></returns> 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(long id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Expenses
        /// <summary>
        /// Create a new expense
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Expense
        ///     
        ///    {
        ///         "id": 1,
        ///         "description": "Cumparatura",
        ///         "sum": 12.25,
        ///         "location": "Lidl",
        ///         "dateAdded": "2020-05-23T21:45:59.2625429+03:00",
        ///         "currency": "Lei",
        ///         "typeOfExpense": "Food",
        ///         "comments": [
        ///             {
        ///                 "id": 4,
        ///                 "text": "bautura",
        ///                 "important": false,
        ///                 "expenseId": 1
        ///             }
        ///                     ]
        ///     }
        ///
        /// </remarks>
        /// <param name="expense"></param>
        /// <returns>Returns the result </returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        /// <summary>
        /// Delete  specific expense
        /// </summary>
        /// <param name="id">Specify the id of the expense you want to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expense>> DeleteExpense(long id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return expense;
        }

        private bool ExpenseExists(long id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
