using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOStudio
	{
		Task<CreateResponse<POCOStudio>> Create(
			ApiStudioModel model);

		Task<ActionResponse> Update(int id,
		                            ApiStudioModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOStudio> Get(int id);

		Task<List<POCOStudio>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>66a022cb30131dc9c858d4526e395bda</Hash>
</Codenesium>*/