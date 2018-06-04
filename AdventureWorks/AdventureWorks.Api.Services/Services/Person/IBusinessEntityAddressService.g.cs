using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IBusinessEntityAddressService
	{
		Task<CreateResponse<ApiBusinessEntityAddressResponseModel>> Create(
			ApiBusinessEntityAddressRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiBusinessEntityAddressRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityAddressResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressID(int addressID);
		Task<List<ApiBusinessEntityAddressResponseModel>> GetAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>26bfb8ed212d4569f84001ed0e9b9c30</Hash>
</Codenesium>*/