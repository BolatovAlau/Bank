using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Bank.BusinessLogic.Entities;

namespace Bank.BusinessLogic
{
    public class EfBatchRepository : IBatchRepository
    {
        protected BankContext db;
        public EfBatchRepository(DbContextOptions options)
        {
            db = new BankContext(options);
        }

        public Batch GetBatch()
        {
            var batch = db.Batches.Include(x => x.Contract)
                .Include(x => x.Contract.ContractData)
                .Include(x => x.Contract.ContractData.TotalAmount)
                .Include(x => x.Contract.ContractData.TotalMonthlyPayment)
                .Include(x => x.Contract.ContractData.ProlongationAmount)
                .Include(x => x.Contract.SubjectRole).First();

            batch.CurentId++;

            db.Entry(batch).State = EntityState.Modified;
            db.SaveChanges();

            return batch;
        }

        #region Disposable
        bool _disposed;

        public void Dispose() // Из Интернета
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }

            }
            _disposed = true;
        }
        #endregion
    }
}
