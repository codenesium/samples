using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IDatabaseLogRepository
        {
                Task<DatabaseLog> Create(DatabaseLog item);

                Task Update(DatabaseLog item);

                Task Delete(int databaseLogID);

                Task<DatabaseLog> Get(int databaseLogID);

                Task<List<DatabaseLog>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>8ba2c58a291ad9609663dd1129ba26b7</Hash>
</Codenesium>*/