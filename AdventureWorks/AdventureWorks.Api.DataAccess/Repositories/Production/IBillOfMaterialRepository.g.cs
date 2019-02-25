using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IBillOfMaterialRepository
	{
		Task<BillOfMaterial> Create(BillOfMaterial item);

		Task Update(BillOfMaterial item);

		Task Delete(int billOfMaterialsID);

		Task<BillOfMaterial> Get(int billOfMaterialsID);

		Task<List<BillOfMaterial>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<BillOfMaterial>> ByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);

		Task<Product> ProductByComponentID(int componentID);

		Task<Product> ProductByProductAssemblyID(int? productAssemblyID);

		Task<UnitMeasure> UnitMeasureByUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>6798aea7f55b98d892664183743c24e9</Hash>
</Codenesium>*/