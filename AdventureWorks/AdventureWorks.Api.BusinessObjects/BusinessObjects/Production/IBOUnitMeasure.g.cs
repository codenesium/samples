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
		Task<CreateResponse<string>> Create(
			UnitMeasureModel model);

		Task<ActionResponse> Update(string unitMeasureCode,
		                            UnitMeasureModel model);

		Task<ActionResponse> Delete(string unitMeasureCode);

		POCOUnitMeasure Get(string unitMeasureCode);

		List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ee347fd36211490b0a2d771bcd85b67e</Hash>
</Codenesium>*/