using System;
using System.Linq.Expressions;
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

		void GetById(int productModelID, Response response);

		void GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a7dc07f85b5d4be30380f8fee5a6cf7b</Hash>
</Codenesium>*/