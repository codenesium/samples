using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOFamily
	{
		Task<CreateResponse<POCOFamily>> Create(
			FamilyModel model);

		Task<ActionResponse> Update(int id,
		                            FamilyModel model);

		Task<ActionResponse> Delete(int id);

		POCOFamily Get(int id);

		List<POCOFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>81a22a4a5da79b8aa912013ebd24ccb5</Hash>
</Codenesium>*/