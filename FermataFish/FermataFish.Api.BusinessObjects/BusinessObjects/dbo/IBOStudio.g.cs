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

		POCOStudio Get(int id);

		List<POCOStudio> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3ec5c447e0e30d11a0289802dabaf93d</Hash>
</Codenesium>*/