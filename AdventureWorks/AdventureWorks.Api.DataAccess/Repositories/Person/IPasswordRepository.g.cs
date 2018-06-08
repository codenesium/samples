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

                Task<List<Password>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>fa44494c80159f395a132b80ee25da0f</Hash>
</Codenesium>*/