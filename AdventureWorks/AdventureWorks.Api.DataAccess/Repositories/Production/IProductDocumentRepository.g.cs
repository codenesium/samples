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

		POCOProductDocument Get(int productID);

		List<POCOProductDocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>88b71302a245cbc21b26063ac3e640ea</Hash>
</Codenesium>*/