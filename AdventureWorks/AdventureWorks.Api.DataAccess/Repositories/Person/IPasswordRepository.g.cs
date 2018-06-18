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

                Task<List<Password>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0dd94b46b6955293eb8d7aece882a675</Hash>
</Codenesium>*/