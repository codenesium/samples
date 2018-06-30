using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface IPostLinksRepository
        {
                Task<PostLinks> Create(PostLinks item);

                Task Update(PostLinks item);

                Task Delete(int id);

                Task<PostLinks> Get(int id);

                Task<List<PostLinks>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e4bbe02af82c3bca16ba62af1f28d59c</Hash>
</Codenesium>*/