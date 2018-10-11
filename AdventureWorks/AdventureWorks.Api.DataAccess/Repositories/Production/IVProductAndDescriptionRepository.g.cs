using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IVProductAndDescriptionRepository
	{
		Task<VProductAndDescription> Get(string cultureID);

		Task<List<VProductAndDescription>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2389b52f6f2ab6e83438df9c34de54f3</Hash>
</Codenesium>*/