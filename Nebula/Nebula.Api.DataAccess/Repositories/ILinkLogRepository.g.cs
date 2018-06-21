using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface ILinkLogRepository
        {
                Task<LinkLog> Create(LinkLog item);

                Task Update(LinkLog item);

                Task Delete(int id);

                Task<LinkLog> Get(int id);

                Task<List<LinkLog>> All(int limit = int.MaxValue, int offset = 0);

                Task<Link> GetLink(int linkId);
        }
}

/*<Codenesium>
    <Hash>8de9a64c37d66d943df1350dd544cd00</Hash>
</Codenesium>*/