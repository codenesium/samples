using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		Task<UnitMeasure> Create(UnitMeasure item);

		Task Update(UnitMeasure item);

		Task Delete(string unitMeasureCode);

		Task<UnitMeasure> Get(string unitMeasureCode);

		Task<List<UnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<UnitMeasure> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>ac06b68afc2338c47b5f01a4d99b2286</Hash>
</Codenesium>*/