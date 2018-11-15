using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICreditCardService
	{
		Task<CreateResponse<ApiCreditCardServerResponseModel>> Create(
			ApiCreditCardServerRequestModel model);

		Task<UpdateResponse<ApiCreditCardServerResponseModel>> Update(int creditCardID,
		                                                               ApiCreditCardServerRequestModel model);

		Task<ActionResponse> Delete(int creditCardID);

		Task<ApiCreditCardServerResponseModel> Get(int creditCardID);

		Task<List<ApiCreditCardServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCreditCardServerResponseModel> ByCardNumber(string cardNumber);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3a9a05b6c8df8020e9ffbfc9d177b402</Hash>
</Codenesium>*/