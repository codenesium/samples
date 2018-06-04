using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IAddressTypeService
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
    <Hash>cd2f672d386c8eb89544fbf6311bb73d</Hash>
</Codenesium>*/