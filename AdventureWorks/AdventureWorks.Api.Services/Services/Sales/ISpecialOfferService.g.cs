using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ISpecialOfferService
	{
		Task<CreateResponse<ApiSpecialOfferResponseModel>> Create(
			ApiSpecialOfferRequestModel model);

		Task<ActionResponse> Update(int specialOfferID,
		                            ApiSpecialOfferRequestModel model);

		Task<ActionResponse> Delete(int specialOfferID);

		Task<ApiSpecialOfferResponseModel> Get(int specialOfferID);

		Task<List<ApiSpecialOfferResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9c8b85589448224dcdc64a21132221be</Hash>
</Codenesium>*/