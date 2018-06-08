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

                Task<List<DatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>0cff9e9220fa79e0bc3948339204ce8a</Hash>
</Codenesium>*/