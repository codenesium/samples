using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICultureRepository
	{
		Task<Culture> Create(Culture item);

		Task Update(Culture item);

		Task Delete(string cultureID);

		Task<Culture> Get(string cultureID);

		Task<List<Culture>> All(int limit = int.MaxValue, int offset = 0);

		Task<Culture> ByName(string name);

		Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCulturesByCultureID(string cultureID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fd170a4cafc7e62484b9e0fd5907f876</Hash>
</Codenesium>*/