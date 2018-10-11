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

		Task<List<BillOfMaterial>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<BillOfMaterial>> ByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>41bb65c55086fcf4aa44d51455692996</Hash>
</Codenesium>*/