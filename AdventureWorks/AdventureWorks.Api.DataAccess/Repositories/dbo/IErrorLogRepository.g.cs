using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IErrorLogRepository
        {
                Task<ErrorLog> Create(ErrorLog item);

                Task Update(ErrorLog item);

                Task Delete(int errorLogID);

                Task<ErrorLog> Get(int errorLogID);

                Task<List<ErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>d7c1064f35a0ac2a97bde17055be18f5</Hash>
</Codenesium>*/