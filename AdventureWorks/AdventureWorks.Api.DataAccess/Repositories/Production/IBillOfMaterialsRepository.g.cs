using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBillOfMaterialsRepository
	{
		Task<DTOBillOfMaterials> Create(DTOBillOfMaterials dto);

		Task Update(int billOfMaterialsID,
		            DTOBillOfMaterials dto);

		Task Delete(int billOfMaterialsID);

		Task<DTOBillOfMaterials> Get(int billOfMaterialsID);

		Task<List<DTOBillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOBillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate);
		Task<List<DTOBillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>aa6179705458c60267c6561d97bef41e</Hash>
</Codenesium>*/