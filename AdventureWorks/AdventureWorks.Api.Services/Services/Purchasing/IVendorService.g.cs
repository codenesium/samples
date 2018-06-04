using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IVendorService
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
    <Hash>43d8b71257888cc4e17283dfc766ae1e</Hash>
</Codenesium>*/