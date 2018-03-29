using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISpecialOfferProductRepository
	{
		int Create(int productID,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int specialOfferID, int productID,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int specialOfferID);

		void GetById(int specialOfferID, Response response);

		void GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9989fc7f40fc9b33f4e92f5b6cb4fdcd</Hash>
</Codenesium>*/