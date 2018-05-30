using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPetRepository
	{
		Task<DTOPet> Create(DTOPet dto);

		Task Update(int id,
		            DTOPet dto);

		Task Delete(int id);

		Task<DTOPet> Get(int id);

		Task<List<DTOPet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b6bd7207f518e43a6929408d29250fed</Hash>
</Codenesium>*/