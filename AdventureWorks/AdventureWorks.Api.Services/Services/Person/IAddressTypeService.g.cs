using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IAddressTypeService
	{
		Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
			ApiAddressTypeRequestModel model);

		Task<UpdateResponse<ApiAddressTypeResponseModel>> Update(int addressTypeID,
		                                                          ApiAddressTypeRequestModel model);

		Task<ActionResponse> Delete(int addressTypeID);

		Task<ApiAddressTypeResponseModel> Get(int addressTypeID);

		Task<List<ApiAddressTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiAddressTypeResponseModel> ByName(string name);

		Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int addressTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a7c5fb891b182742529b78ef05abe58f</Hash>
</Codenesium>*/