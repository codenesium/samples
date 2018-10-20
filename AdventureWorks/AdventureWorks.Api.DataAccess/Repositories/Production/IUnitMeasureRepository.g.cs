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

		Task<List<BillOfMaterial>> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<Product>> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<List<Product>> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bb87ca7eaddb6be8e3a40c03b54ed9b9</Hash>
</Codenesium>*/