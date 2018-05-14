using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOUnitMeasure
	{
		Task<CreateResponse<POCOUnitMeasure>> Create(
			ApiUnitMeasureModel model);

		Task<ActionResponse> Update(string unitMeasureCode,
		                            ApiUnitMeasureModel model);

		Task<ActionResponse> Delete(string unitMeasureCode);

		POCOUnitMeasure Get(string unitMeasureCode);

		List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOUnitMeasure GetName(string name);
	}
}

/*<Codenesium>
    <Hash>676c8b6fc51d0e82d6ba50f903262d13</Hash>
</Codenesium>*/