using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IBusinessEntityContactService
	{
		Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
			ApiBusinessEntityContactRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiBusinessEntityContactRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityContactResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiBusinessEntityContactResponseModel>> GetContactTypeID(int contactTypeID);
		Task<List<ApiBusinessEntityContactResponseModel>> GetPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>9d9a3b3955b978a1e7549e8bc7bb5066</Hash>
</Codenesium>*/