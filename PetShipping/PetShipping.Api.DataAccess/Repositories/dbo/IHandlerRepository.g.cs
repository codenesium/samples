using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerRepository
	{
		Task<DTOHandler> Create(DTOHandler dto);

		Task Update(int id,
		            DTOHandler dto);

		Task Delete(int id);

		Task<DTOHandler> Get(int id);

		Task<List<DTOHandler>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ee1116769e441891e73838bd119b8b0e</Hash>
</Codenesium>*/