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

                Task<List<DatabaseLog>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>189655744598c62a210ea22fe9ef0bf9</Hash>
</Codenesium>*/