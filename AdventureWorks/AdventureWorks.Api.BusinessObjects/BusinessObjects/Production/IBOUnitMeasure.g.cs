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

		Task<POCOUnitMeasure> Get(string unitMeasureCode);

		Task<List<POCOUnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOUnitMeasure> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>f385ef5c92e4a870e258fdb703111324</Hash>
</Codenesium>*/