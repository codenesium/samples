using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBillOfMaterialsRepository
	{
		int Create(BillOfMaterialsModel model);

		void Update(int billOfMaterialsID,
		            BillOfMaterialsModel model);

		void Delete(int billOfMaterialsID);

		POCOBillOfMaterials Get(int billOfMaterialsID);

		List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fcb471724930b52415e22abc6b27b755</Hash>
</Codenesium>*/