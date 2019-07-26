using Bank.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BusinessLogic
{
    public interface IBatchRepository : IDisposable
    {
        Batch GetBatch();
    }
}
