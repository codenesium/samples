using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAddressType
	{
		Task<CreateResponse<ApiAddressTypeResponseModel>> Create(
			ApiAddressTypeRequestModel model);

		Task<ActionResponse> Update(int addressTypeID,
		                            ApiAddressTypeRequestModel model);

		Task<ActionResponse> Delete(int addressTypeID);

		Task<ApiAddressTypeResponseModel> Get(int addressTypeID);

		Task<List<ApiAddressTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiAddressTypeResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>064cf2c6cbf88c03b6072e1577d586d8</Hash>
</Codenesium>*/