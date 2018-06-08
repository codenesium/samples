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

                Task<List<LinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>483e9b7877870c706296831e6d88ab7c</Hash>
</Codenesium>*/