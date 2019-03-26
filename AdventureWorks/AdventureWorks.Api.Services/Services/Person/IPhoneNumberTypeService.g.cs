using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IPhoneNumberTypeService
	{
		Task<CreateResponse<ApiPhoneNumberTypeServerResponseModel>> Create(
			ApiPhoneNumberTypeServerRequestModel model);

		Task<UpdateResponse<ApiPhoneNumberTypeServerResponseModel>> Update(int phoneNumberTypeID,
		                                                                    ApiPhoneNumberTypeServerRequestModel model);

		Task<ActionResponse> Delete(int phoneNumberTypeID);

		Task<ApiPhoneNumberTypeServerResponseModel> Get(int phoneNumberTypeID);

		Task<List<ApiPhoneNumberTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>930f4649e8ae6411828e7d5fe558681f</Hash>
</Codenesium>*/