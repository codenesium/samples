using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityAddress
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
    <Hash>ed7313e223a890f91b5a8a664df68364</Hash>
</Codenesium>*/