using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCategoryRepository
	{
		int Create(string name,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int productCategoryID, string name,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int productCategoryID);

		void GetById(int productCategoryID, Response response);

		void GetWhere(Expression<Func<EFProductCategory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>48dcc7afb8c5d8f1c24e639ca0632ce0</Hash>
</Codenesium>*/