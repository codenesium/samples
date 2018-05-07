using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		string Create(UnitMeasureModel model);

		void Update(string unitMeasureCode,
		            UnitMeasureModel model);

		void Delete(string unitMeasureCode);

		POCOUnitMeasure Get(string unitMeasureCode);

		List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d809fd0e3e454dfda53b8f44aad1df42</Hash>
</Codenesium>*/