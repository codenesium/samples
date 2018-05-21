using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDocumentRepository
	{
		Task<POCOProductDocument> Create(ApiProductDocumentModel model);

		Task Update(int productID,
		            ApiProductDocumentModel model);

		Task Delete(int productID);

		Task<POCOProductDocument> Get(int productID);

		Task<List<POCOProductDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2e28f512dc4e898ffc52f705c8519a7f</Hash>
</Codenesium>*/