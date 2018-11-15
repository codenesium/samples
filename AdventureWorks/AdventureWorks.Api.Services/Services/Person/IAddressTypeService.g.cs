using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IAddressTypeService
	{
		Task<CreateResponse<ApiAddressTypeServerResponseModel>> Create(
			ApiAddressTypeServerRequestModel model);

		Task<UpdateResponse<ApiAddressTypeServerResponseModel>> Update(int addressTypeID,
		                                                                ApiAddressTypeServerRequestModel model);

		Task<ActionResponse> Delete(int addressTypeID);

		Task<ApiAddressTypeServerResponseModel> Get(int addressTypeID);

		Task<List<ApiAddressTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiAddressTypeServerResponseModel> ByName(string name);

		Task<ApiAddressTypeServerResponseModel> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>15d5c8deb9647072387ba3809a579ecc</Hash>
</Codenesium>*/