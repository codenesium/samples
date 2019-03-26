using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPersonService
	{
		Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model);

		Task<UpdateResponse<ApiPersonServerResponseModel>> Update(int businessEntityID,
		                                                           ApiPersonServerRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPersonServerResponseModel> Get(int businessEntityID);

		Task<List<ApiPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiPersonServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiPersonServerResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonServerResponseModel>> ByAdditionalContactInfo(string additionalContactInfo, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonServerResponseModel>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPasswordServerResponseModel>> PasswordsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b16ab5a0f57cb2ecc4a3940d827ac410</Hash>
</Codenesium>*/