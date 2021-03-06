﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouthApp.Context;
using YouthApp.Models;

namespace bStudioSchoolManager.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public PaymentsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> Student(long id) => await new ApplicationDbContext(dco).Payments.Where(x => x.StudentsID == id).OrderByDescending(x => x.DatePaid).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(Guid id)
        {
            var pay = await new ApplicationDbContext(dco).Payments.FindAsync(id);
            return pay == null ? (IActionResult)NotFound(new { Message = "Payment was not found" }) : Ok(pay);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Payments payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                var std = await db.Students.FindAsync(payment.StudentsID);
                if (std == null)
                    return BadRequest(new { Message = "Payment could not be accepted as the student could not be found" });
                var rev = await db.Revenues.Where(x => x.Source == "IGF").FirstOrDefaultAsync();
                var tran = new Transactions
                {
                    RevenuesID = rev.RevenuesID,
                    Amount = payment.Amount,
                    TransactionDate = DateTime.Now,
                    TransactionsTypesID = (byte)TranTypes.Revenue,
                    TransactionItemsID = 7,
                    Purpose = $"School fees payment by :{std.Surname} {std.OtherNames ?? ""}. GCR :{payment.GCR}",
                    Payments = payment
                };
                db.Add(tran);
                await db.SaveChangesAsync();
            }
            return Created($"/Payments/Payment?id={payment.PaymentsID}", new { payment.TransactionsID, payment.StudentsID, payment.Receiver, payment.PaymentsID, payment.GCR, payment.DatePaid, payment.Amount });
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Payments payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                Transactions tran = await db.Transactions.SingleOrDefaultAsync(x => x.TransactionsID == payment.TransactionsID);
                if (tran == null)
                    return BadRequest(new { Message = "Edit failed. Related transaction could not be found" });
                var pay = await db.Payments.FindAsync(payment.PaymentsID);
                if (pay == null)
                    return BadRequest(new { Message = "Edit failed. Payment could not be found" });
                pay.Amount = payment.Amount;
                pay.DatePaid = payment.DatePaid;
                pay.GCR = payment.GCR;
                db.Entry(tran).State = EntityState.Modified;
                db.Entry(pay).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Payments/Payment?id={payment.PaymentsID}", new { payment.TransactionsID, payment.StudentsID, payment.Receiver, payment.PaymentsID, payment.GCR, payment.DatePaid, payment.Amount });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Payments payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                Transactions tran = await db.Transactions.SingleOrDefaultAsync(x => x.TransactionsID == payment.TransactionsID);
                if (tran == null)
                    return BadRequest(new { Message = "Edit failed. Related transaction could not be found" });
                var pay = await db.Payments.FindAsync(payment.PaymentsID);
                if (pay == null)
                    return BadRequest(new { Message = "Edit failed. Payment could not be found" });
                db.Entry(tran).State = EntityState.Deleted;
                db.Entry(pay).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            return Created($"/Payments/Payment?id={payment.PaymentsID}", new { payment.TransactionsID, payment.StudentsID, payment.Receiver, payment.PaymentsID, payment.GCR, payment.DatePaid, payment.Amount });
        }
    }
}