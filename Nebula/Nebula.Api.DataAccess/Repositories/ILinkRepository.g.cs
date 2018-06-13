using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ILinkRepository
        {
                Task<Link> Create(Link item);

                Task Update(Link item);

                Task Delete(int id);

                Task<Link> Get(int id);

                Task<List<Link>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<LinkLog>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>654b6433522fd05b9fbce94beabae2fd</Hash>
</Codenesium>*/