using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOVendor
	{
		Task<CreateResponse<ApiVendorResponseModel>> Create(
			ApiVendorRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiVendorRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiVendorResponseModel> Get(int businessEntityID);

		Task<List<ApiVendorResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiVendorResponseModel> GetAccountNumber(string accountNumber);
	}
}

/*<Codenesium>
    <Hash>c0cdde5807dd82da23e2ad43339879b2</Hash>
</Codenesium>*/