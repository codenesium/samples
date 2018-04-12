using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		int Create(
			string name,
			string catalogDescription,
			string instructions,
			Guid rowguid,
			DateTime modifiedDate);

		void Update(int productModelID,
		            string name,
		            string catalogDescription,
		            string instructions,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productModelID);

		Response GetById(int productModelID);

		POCOProductModel GetByIdDirect(int productModelID);

		Response GetWhere(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModel> GetWhereDirect(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>905136b547c35cfb2537b61c3fcc111c</Hash>
</Codenesium>*/