using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IUnitMeasureRepository
	{
		Task<UnitMeasure> Create(UnitMeasure item);

		Task Update(UnitMeasure item);

		Task Delete(string unitMeasureCode);

		Task<UnitMeasure> Get(string unitMeasureCode);

		Task<List<UnitMeasure>> All(int limit = int.MaxValue, int offset = 0);

		Task<UnitMeasure> ByName(string name);

		Task<List<BillOfMaterial>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<Product>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0bd4051eb6a169c8f25cae54e8d31885</Hash>
</Codenesium>*/