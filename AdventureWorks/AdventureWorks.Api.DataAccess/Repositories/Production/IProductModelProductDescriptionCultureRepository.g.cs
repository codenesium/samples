using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelProductDescriptionCultureRepository
	{
		int Create(int productDescriptionID,
		           string cultureID,
		           DateTime modifiedDate);

		void Update(int productModelID, int productDescriptionID,
		            string cultureID,
		            DateTime modifiedDate);

		void Delete(int productModelID);

		Response GetById(int productModelID);

		POCOProductModelProductDescriptionCulture GetByIdDirect(int productModelID);

		Response GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductModelProductDescriptionCulture> GetWhereDirect(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b4749ca3aa8761c4215e49654f037fa5</Hash>
</Codenesium>*/