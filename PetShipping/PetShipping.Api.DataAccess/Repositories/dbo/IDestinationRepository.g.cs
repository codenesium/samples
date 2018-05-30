using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IDestinationRepository
	{
		Task<DTODestination> Create(DTODestination dto);

		Task Update(int id,
		            DTODestination dto);

		Task Delete(int id);

		Task<DTODestination> Get(int id);

		Task<List<DTODestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fbf5e3e46ae6aaafd95fddfee9da466a</Hash>
</Codenesium>*/