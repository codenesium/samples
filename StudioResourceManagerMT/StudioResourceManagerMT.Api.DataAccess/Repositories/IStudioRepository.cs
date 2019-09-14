using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	public partial interface IStudioRepository
	{
		Task<Studio> Create(Studio item);

		Task Update(Studio item);

		Task Delete(int id);

		Task<Studio> Get(int id);

		Task<List<Studio>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>381fbb51bcda2b526a9afae03d4f36a0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/