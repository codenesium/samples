using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerRepository
	{
		Task<POCOHandler> Create(ApiHandlerModel model);

		Task Update(int id,
		            ApiHandlerModel model);

		Task Delete(int id);

		Task<POCOHandler> Get(int id);

		Task<List<POCOHandler>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>47380ff44366ec9e399cd50514f9c312</Hash>
</Codenesium>*/