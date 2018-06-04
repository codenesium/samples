using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerRepository
	{
		Task<Handler> Create(Handler item);

		Task Update(Handler item);

		Task Delete(int id);

		Task<Handler> Get(int id);

		Task<List<Handler>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c386e5493c10c991abacd083e5015e19</Hash>
</Codenesium>*/