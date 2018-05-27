using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCreditCard
	{
		Task<CreateResponse<ApiCreditCardResponseModel>> Create(
			ApiCreditCardRequestModel model);

		Task<ActionResponse> Update(int creditCardID,
		                            ApiCreditCardRequestModel model);

		Task<ActionResponse> Delete(int creditCardID);

		Task<ApiCreditCardResponseModel> Get(int creditCardID);

		Task<List<ApiCreditCardResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiCreditCardResponseModel> GetCardNumber(string cardNumber);
	}
}

/*<Codenesium>
    <Hash>2deda6460592941d8c4eeaae095da311</Hash>
</Codenesium>*/