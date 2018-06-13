using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ILinkLogRepository
        {
                Task<LinkLog> Create(LinkLog item);

                Task Update(LinkLog item);

                Task Delete(int id);

                Task<LinkLog> Get(int id);

                Task<List<LinkLog>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>d62c49059601cc42452b9a7574f330a0</Hash>
</Codenesium>*/