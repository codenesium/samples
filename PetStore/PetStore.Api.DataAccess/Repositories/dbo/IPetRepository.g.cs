using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>459cfff4973e15c29d3ee66c5ef309ab</Hash>
</Codenesium>*/