using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductSubcategoryRepository
	{
		int Create(int productCategoryID,
		           string name,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productSubcategoryID, int productCategoryID,
		            string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productSubcategoryID);

		void GetById(int productSubcategoryID, Response response);

		void GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>87809c7c6a27f729090ff97d04832adb</Hash>
</Codenesium>*/