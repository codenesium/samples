using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IIllustrationService
	{
		Task<CreateResponse<ApiIllustrationResponseModel>> Create(
			ApiIllustrationRequestModel model);

		Task<ActionResponse> Update(int illustrationID,
		                            ApiIllustrationRequestModel model);

		Task<ActionResponse> Delete(int illustrationID);

		Task<ApiIllustrationResponseModel> Get(int illustrationID);

		Task<List<ApiIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>26eb83ae5716f8975ceff379d663b8b4</Hash>
</Codenesium>*/