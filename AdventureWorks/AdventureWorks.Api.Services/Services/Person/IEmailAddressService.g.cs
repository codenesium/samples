using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IEmailAddressService
	{
		Task<CreateResponse<ApiEmailAddressResponseModel>> Create(
			ApiEmailAddressRequestModel model);

		Task<UpdateResponse<ApiEmailAddressResponseModel>> Update(int businessEntityID,
		                                                           ApiEmailAddressRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiEmailAddressResponseModel> Get(int businessEntityID);

		Task<List<ApiEmailAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEmailAddressResponseModel>> ByEmailAddress(string emailAddress1, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9902a47616a3c75557dd5cb2e4d81fdd</Hash>
</Codenesium>*/