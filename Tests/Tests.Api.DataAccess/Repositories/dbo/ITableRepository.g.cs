using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface ITableRepository
        {
                Task<Table> Create(Table item);

                Task Update(Table item);

                Task Delete(int id);

                Task<Table> Get(int id);

                Task<List<Table>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>70f26527df0358163618c9519c9c02bc</Hash>
</Codenesium>*/