using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDocumentRepository
	{
		int Create(Guid documentNode,
		           DateTime modifiedDate);

		void Update(int productID, Guid documentNode,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProductDocument GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductDocument> GetWhereDirect(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5547e2ead12ae2a318ca7edfbecd3cc3</Hash>
</Codenesium>*/