using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBillOfMaterialsRepository
	{
		int Create(Nullable<int> productAssemblyID,
		           int componentID,
		           DateTime startDate,
		           Nullable<DateTime> endDate,
		           string unitMeasureCode,
		           short bOMLevel,
		           decimal perAssemblyQty,
		           DateTime modifiedDate);

		void Update(int billOfMaterialsID, Nullable<int> productAssemblyID,
		            int componentID,
		            DateTime startDate,
		            Nullable<DateTime> endDate,
		            string unitMeasureCode,
		            short bOMLevel,
		            decimal perAssemblyQty,
		            DateTime modifiedDate);

		void Delete(int billOfMaterialsID);

		void GetById(int billOfMaterialsID, Response response);

		void GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dd4c399f501dd3305c9b3480517e5806</Hash>
</Codenesium>*/