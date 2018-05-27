using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPenRepository
	{
		Task<DTOPen> Create(DTOPen dto);

		Task Update(int id,
		            DTOPen dto);

		Task Delete(int id);

		Task<DTOPen> Get(int id);

		Task<List<DTOPen>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f0301b246df9037992519cab5d02be92</Hash>
</Codenesium>*/