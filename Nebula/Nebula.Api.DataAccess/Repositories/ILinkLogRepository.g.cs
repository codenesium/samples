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

                Task<List<LinkLog>> All(int limit = int.MaxValue, int offset = 0);

                Task<Link> GetLink(int linkId);
        }
}

/*<Codenesium>
    <Hash>f4a4880dca80f35de6ab8cc424e1067d</Hash>
</Codenesium>*/