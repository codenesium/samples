using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>2a0d179ca40fa7a4d55406a769368ec8</Hash>
</Codenesium>*/