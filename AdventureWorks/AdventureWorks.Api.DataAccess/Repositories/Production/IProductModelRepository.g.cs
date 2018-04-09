using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		int Create(string name,
		           string catalogDescription,
		           string instructions,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productModelID, string name,
		            string catalogDescription,
		            string instructions,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productModelID);

		Response GetById(int productModelID);

		POCOProductModel GetByIdDirect(int productModelID);

		Response GetWhere(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductModel> GetWhereDirect(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a0e317b23c5e620a21fb154889876560</Hash>
</Codenesium>*/