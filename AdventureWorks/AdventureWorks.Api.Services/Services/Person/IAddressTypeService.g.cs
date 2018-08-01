using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IAddressTypeService
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
    <Hash>b1a9589efeeb8941fd4b61cc2489acf2</Hash>
</Codenesium>*/