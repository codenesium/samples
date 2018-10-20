using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICreditCardService
	{
		Task<CreateResponse<ApiCreditCardResponseModel>> Create(
			ApiCreditCardRequestModel model);

		Task<UpdateResponse<ApiCreditCardResponseModel>> Update(int creditCardID,
		                                                         ApiCreditCardRequestModel model);

		Task<ActionResponse> Delete(int creditCardID);

		Task<ApiCreditCardResponseModel> Get(int creditCardID);

		Task<List<ApiCreditCardResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCreditCardResponseModel> ByCardNumber(string cardNumber);

		Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCreditCardResponseModel>> ByBusinessEntityID(int creditCardID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2667552ef672e83c86dce96f5d7b5846</Hash>
</Codenesium>*/