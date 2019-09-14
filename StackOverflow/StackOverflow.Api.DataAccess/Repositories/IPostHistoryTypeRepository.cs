using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface IPostHistoryTypeRepository
	{
		Task<PostHistoryType> Create(PostHistoryType item);

		Task Update(PostHistoryType item);

		Task Delete(int id);

		Task<PostHistoryType> Get(int id);

		Task<List<PostHistoryType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PostHistory>> PostHistoriesByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>10eec3d23bcf7fb73439a939d546f409</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/