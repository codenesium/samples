using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISpeciesRepository
	{
		Task<DTOSpecies> Create(DTOSpecies dto);

		Task Update(int id,
		            DTOSpecies dto);

		Task Delete(int id);

		Task<DTOSpecies> Get(int id);

		Task<List<DTOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a268ae161e0028885de19cfecc9e156a</Hash>
</Codenesium>*/