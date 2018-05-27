using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
	{
		Task<DTOUnitMeasure> Create(DTOUnitMeasure dto);

		Task Update(string unitMeasureCode,
		            DTOUnitMeasure dto);

		Task Delete(string unitMeasureCode);

		Task<DTOUnitMeasure> Get(string unitMeasureCode);

		Task<List<DTOUnitMeasure>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOUnitMeasure> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>b74215056e5f4e165cc81544db3fd8f1</Hash>
</Codenesium>*/