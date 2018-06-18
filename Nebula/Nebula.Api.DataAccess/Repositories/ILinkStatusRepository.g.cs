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

                Task<List<LinkStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Link>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>611c99030a96cc834fd76d4adb4a9af5</Hash>
</Codenesium>*/