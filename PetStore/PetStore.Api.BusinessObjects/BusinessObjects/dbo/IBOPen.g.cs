using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOPen
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
    <Hash>3483d7aac1178ce60c69c830cda80a45</Hash>
</Codenesium>*/