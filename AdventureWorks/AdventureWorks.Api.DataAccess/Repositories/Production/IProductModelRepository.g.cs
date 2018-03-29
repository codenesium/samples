using System;
using System.Linq.Expressions;
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

		void GetById(int productModelID, Response response);

		void GetWhere(Expression<Func<EFProductModel, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f185166b1a3a2ab62d05a6f6e872cb92</Hash>
</Codenesium>*/