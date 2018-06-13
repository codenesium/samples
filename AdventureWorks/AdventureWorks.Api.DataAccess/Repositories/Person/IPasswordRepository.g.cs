using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPasswordRepository
        {
                Task<Password> Create(Password item);

                Task Update(Password item);

                Task Delete(int businessEntityID);

                Task<Password> Get(int businessEntityID);

                Task<List<Password>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9ed6b06a31afacdcb86fd5fade4d9c07</Hash>
</Codenesium>*/