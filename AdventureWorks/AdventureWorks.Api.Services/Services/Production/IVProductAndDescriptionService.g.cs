using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IVProductAndDescriptionService
	{
		Task<ApiVProductAndDescriptionResponseModel> Get(string cultureID);

		Task<List<ApiVProductAndDescriptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6f8c9a7ebe1acca090f965b9a2f6e0f4</Hash>
</Codenesium>*/