using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityContact
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
    <Hash>c1ca3167f30eaea14f8480d700841556</Hash>
</Codenesium>*/