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

		Task<List<ApiEmailAddressResponseModel>> ByEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>a4b0c14db30f0cd9436a473aeb24a301</Hash>
</Codenesium>*/