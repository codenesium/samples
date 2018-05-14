using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDocumentRepository
	{
		POCOProductDocument Create(ApiProductDocumentModel model);

		void Update(int productID,
		            ApiProductDocumentModel model);

		void Delete(int productID);

		POCOProductDocument Get(int productID);

		List<POCOProductDocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>29723cc7dd1db92b40b6c80d9755c6b7</Hash>
</Codenesium>*/