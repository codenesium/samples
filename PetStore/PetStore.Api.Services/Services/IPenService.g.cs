using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public interface IPenService
	{
		Task<CreateResponse<ApiPenResponseModel>> Create(
			ApiPenRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPenRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPenResponseModel> Get(int id);

		Task<List<ApiPenResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>19ed3487692c685ed093c77df59ec5c0</Hash>
</Codenesium>*/