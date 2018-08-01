using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IUnitMeasureRepository
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
    <Hash>ff52f4eb9bd6032a827c49e69c51fb67</Hash>
</Codenesium>*/