using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface ITagsRepository
        {
                Task<Tags> Create(Tags item);

                Task Update(Tags item);

                Task Delete(int id);

                Task<Tags> Get(int id);

                Task<List<Tags>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e01ab985572007a8634ca92da5820706</Hash>
</Codenesium>*/