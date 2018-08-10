using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPersonCreditCardService
	{
		Task<CreateResponse<ApiPersonCreditCardResponseModel>> Create(
			ApiPersonCreditCardRequestModel model);

		Task<UpdateResponse<ApiPersonCreditCardResponseModel>> Update(int businessEntityID,
		                                                               ApiPersonCreditCardRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPersonCreditCardResponseModel> Get(int businessEntityID);

		Task<List<ApiPersonCreditCardResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3b6efadd05f71b4d8bde85c1bf14920c</Hash>
</Codenesium>*/