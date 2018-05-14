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
			StudioModel model);

		Task<ActionResponse> Update(int id,
		                            StudioModel model);

		Task<ActionResponse> Delete(int id);

		POCOStudio Get(int id);

		List<POCOStudio> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cc16a5bf0b02549977fbb7ba8103080c</Hash>
</Codenesium>*/