using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		POCOUnitMeasure Create(ApiUnitMeasureModel model);

		void Update(string unitMeasureCode,
		            ApiUnitMeasureModel model);

		void Delete(string unitMeasureCode);

		POCOUnitMeasure Get(string unitMeasureCode);

		List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOUnitMeasure GetName(string name);
	}
}

/*<Codenesium>
    <Hash>ef7279c02d0060725499804020fd298f</Hash>
</Codenesium>*/