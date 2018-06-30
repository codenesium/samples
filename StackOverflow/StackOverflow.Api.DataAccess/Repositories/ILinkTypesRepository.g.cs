using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface ILinkTypesRepository
        {
                Task<LinkTypes> Create(LinkTypes item);

                Task Update(LinkTypes item);

                Task Delete(int id);

                Task<LinkTypes> Get(int id);

                Task<List<LinkTypes>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>16bdde7577b981558b3a7872f6020f6d</Hash>
</Codenesium>*/