using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		Task<DTOEmployee> Create(DTOEmployee dto);

		Task Update(int id,
		            DTOEmployee dto);

		Task Delete(int id);

		Task<DTOEmployee> Get(int id);

		Task<List<DTOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>639a1b69e98393286f14a620813ac1ce</Hash>
</Codenesium>*/