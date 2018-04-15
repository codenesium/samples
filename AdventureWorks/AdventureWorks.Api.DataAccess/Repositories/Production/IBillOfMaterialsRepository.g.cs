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

		ApiResponse GetById(int billOfMaterialsID);

		POCOBillOfMaterials GetByIdDirect(int billOfMaterialsID);

		ApiResponse GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBillOfMaterials> GetWhereDirect(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f714e1ce48f8ceb20ca2b5ed9c27f476</Hash>
</Codenesium>*/