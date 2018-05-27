using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDocumentRepository
	{
		Task<DTOProductDocument> Create(DTOProductDocument dto);

		Task Update(int productID,
		            DTOProductDocument dto);

		Task Delete(int productID);

		Task<DTOProductDocument> Get(int productID);

		Task<List<DTOProductDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a8fd9f9479a82f2c2c37d8d701fa4cc3</Hash>
</Codenesium>*/