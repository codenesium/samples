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

		Task<List<ApiCreditCardServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiCreditCardServerResponseModel> ByCardNumber(string cardNumber);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCreditCardID(int creditCardID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>83ac4ca0e7853490cb2e2bbfff38e22e</Hash>
</Codenesium>*/