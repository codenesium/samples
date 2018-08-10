using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IContactTypeService
	{
		Task<CreateResponse<ApiContactTypeResponseModel>> Create(
			ApiContactTypeRequestModel model);

		Task<UpdateResponse<ApiContactTypeResponseModel>> Update(int contactTypeID,
		                                                          ApiContactTypeRequestModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		Task<ApiContactTypeResponseModel> Get(int contactTypeID);

		Task<List<ApiContactTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiContactTypeResponseModel> ByName(string name);

		Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>724bf82ebbd1a47553659d5a22d70b9d</Hash>
</Codenesium>*/