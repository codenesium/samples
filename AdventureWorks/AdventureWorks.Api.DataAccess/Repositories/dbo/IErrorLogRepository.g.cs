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

                Task<List<ErrorLog>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>718bc71d44834afabafa2cdb7d7b6e0f</Hash>
</Codenesium>*/