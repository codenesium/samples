using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPersonService
	{
		Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model);

		Task<UpdateResponse<ApiPersonResponseModel>> Update(int businessEntityID,
		                                                     ApiPersonRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPersonResponseModel> Get(int businessEntityID);

		Task<List<ApiPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonResponseModel>> ByAdditionalContactInfo(string additionalContactInfo, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonResponseModel>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContactsByPersonID(int personID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEmailAddressResponseModel>> EmailAddressesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPasswordResponseModel>> PasswordsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonPhoneResponseModel>> PersonPhonesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7925f6b085444702ff69d100195d1274</Hash>
</Codenesium>*/