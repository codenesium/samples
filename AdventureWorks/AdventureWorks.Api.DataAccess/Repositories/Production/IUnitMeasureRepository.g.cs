using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		Task<POCOUnitMeasure> Create(ApiUnitMeasureModel model);

		Task Update(string unitMeasureCode,
		            ApiUnitMeasureModel model);

		Task Delete(string unitMeasureCode);

		Task<POCOUnitMeasure> Get(string unitMeasureCode);

		Task<List<POCOUnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOUnitMeasure> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>b88100a9e78cd889907d825422629f22</Hash>
</Codenesium>*/