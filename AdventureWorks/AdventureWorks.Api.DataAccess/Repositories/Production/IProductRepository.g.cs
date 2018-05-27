using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductRepository
	{
		Task<DTOProduct> Create(DTOProduct dto);

		Task Update(int productID,
		            DTOProduct dto);

		Task Delete(int productID);

		Task<DTOProduct> Get(int productID);

		Task<List<DTOProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOProduct> GetName(string name);
		Task<DTOProduct> GetProductNumber(string productNumber);
	}
}

/*<Codenesium>
    <Hash>75d198c9d7cd378afbd85c2f6a694a51</Hash>
</Codenesium>*/