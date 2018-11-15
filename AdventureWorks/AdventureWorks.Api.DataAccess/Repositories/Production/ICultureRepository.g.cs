using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICultureRepository
	{
		Task<Culture> Create(Culture item);

		Task Update(Culture item);

		Task Delete(string cultureID);

		Task<Culture> Get(string cultureID);

		Task<List<Culture>> All(int limit = int.MaxValue, int offset = 0);

		Task<Culture> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>4528115490a45c9f41c0d4ac0d6da8eb</Hash>
</Codenesium>*/