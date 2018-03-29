using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		int Create(int productPhotoID,
		           bool primary,
		           DateTime modifiedDate);

		void Update(int productID, int productPhotoID,
		            bool primary,
		            DateTime modifiedDate);

		void Delete(int productID);

		void GetById(int productID, Response response);

		void GetWhere(Expression<Func<EFProductProductPhoto, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c55e9e81fb7573125edb80c64a81d78b</Hash>
</Codenesium>*/