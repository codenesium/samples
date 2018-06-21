using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
        public interface IPostHistoryTypesRepository
        {
                Task<PostHistoryTypes> Create(PostHistoryTypes item);

                Task Update(PostHistoryTypes item);

                Task Delete(int id);

                Task<PostHistoryTypes> Get(int id);

                Task<List<PostHistoryTypes>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>73704718894fe2ebd83265717d435cd1</Hash>
</Codenesium>*/