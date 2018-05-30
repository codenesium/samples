using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ISaleRepository
	{
		Task<DTOSale> Create(DTOSale dto);

		Task Update(int id,
		            DTOSale dto);

		Task Delete(int id);

		Task<DTOSale> Get(int id);

		Task<List<DTOSale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9b5acfb6e0782daf78697e607c9a807d</Hash>
</Codenesium>*/