using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBillOfMaterialsRepository
	{
		POCOBillOfMaterials Create(ApiBillOfMaterialsModel model);

		void Update(int billOfMaterialsID,
		            ApiBillOfMaterialsModel model);

		void Delete(int billOfMaterialsID);

		POCOBillOfMaterials Get(int billOfMaterialsID);

		List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOBillOfMaterials GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate);

		List<POCOBillOfMaterials> GetUnitMeasureCode(string unitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>c6ae17f677541a667d177575da408ed9</Hash>
</Codenesium>*/