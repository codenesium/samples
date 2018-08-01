using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBillOfMaterialRepository
	{
		Task<BillOfMaterial> Create(BillOfMaterial item);

		Task Update(BillOfMaterial item);

		Task Delete(int billOfMaterialsID);

		Task<BillOfMaterial> Get(int billOfMaterialsID);

		Task<List<BillOfMaterial>> All(int limit = int.MaxValue, int offset = 0);

		Task<BillOfMaterial> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate);

		Task<List<BillOfMaterial>> ByUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>5f0144c3aa3346f116683dc31ce8ae31</Hash>
</Codenesium>*/