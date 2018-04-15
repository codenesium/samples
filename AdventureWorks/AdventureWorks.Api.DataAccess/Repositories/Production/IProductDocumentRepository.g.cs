using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDocumentRepository
	{
		int Create(ProductDocumentModel model);

		void Update(int productID,
		            ProductDocumentModel model);

		void Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductDocument GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductDocument> GetWhereDirect(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>17a2b038947d60fe7f67492dbb6e0685</Hash>
</Codenesium>*/