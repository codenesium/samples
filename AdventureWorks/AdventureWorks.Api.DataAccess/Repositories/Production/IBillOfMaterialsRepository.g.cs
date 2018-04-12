using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBillOfMaterialsRepository
	{
		int Create(
			Nullable<int> productAssemblyID,
			int componentID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			string unitMeasureCode,
			short bOMLevel,
			decimal perAssemblyQty,
			DateTime modifiedDate);

		void Update(int billOfMaterialsID,
		            Nullable<int> productAssemblyID,
		            int componentID,
		            DateTime startDate,
		            Nullable<DateTime> endDate,
		            string unitMeasureCode,
		            short bOMLevel,
		            decimal perAssemblyQty,
		            DateTime modifiedDate);

		void Delete(int billOfMaterialsID);

		Response GetById(int billOfMaterialsID);

		POCOBillOfMaterials GetByIdDirect(int billOfMaterialsID);

		Response GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBillOfMaterials> GetWhereDirect(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b4086dbcc029db05038652ec9d0f9c0a</Hash>
</Codenesium>*/