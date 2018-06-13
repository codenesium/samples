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

                Task<List<ErrorLog>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>71a2cc09f10d3028f8aff8a9aeb723b7</Hash>
</Codenesium>*/