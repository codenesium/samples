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

                Task<List<LinkLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>177a5d8d24add03c6dffeb8634247b41</Hash>
</Codenesium>*/