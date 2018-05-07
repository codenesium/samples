using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOStateProvince
	{
		Task<CreateResponse<int>> Create(
			StateProvinceModel model);

		Task<ActionResponse> Update(int stateProvinceID,
		                            StateProvinceModel model);

		Task<ActionResponse> Delete(int stateProvinceID);

		POCOStateProvince Get(int stateProvinceID);

		List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4945c06c138b006dc415a39f60ae46a7</Hash>
</Codenesium>*/