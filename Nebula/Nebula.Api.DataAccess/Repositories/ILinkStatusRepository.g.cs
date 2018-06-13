using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ILinkStatusRepository
        {
                Task<LinkStatus> Create(LinkStatus item);

                Task Update(LinkStatus item);

                Task Delete(int id);

                Task<LinkStatus> Get(int id);

                Task<List<LinkStatus>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Link>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0d4bb28f57a163311b3455cd061c27a0</Hash>
</Codenesium>*/