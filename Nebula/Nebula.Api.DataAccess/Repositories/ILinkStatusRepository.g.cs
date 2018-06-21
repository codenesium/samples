using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ILinkStatusRepository
        {
                Task<LinkStatus> Create(LinkStatus item);

                Task Update(LinkStatus item);

                Task Delete(int id);

                Task<LinkStatus> Get(int id);

                Task<List<LinkStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Link>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>88f4d7880b379d21e8c12caf085edb38</Hash>
</Codenesium>*/