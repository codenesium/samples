using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentRepository
	{
		Task<DTOStudent> Create(DTOStudent dto);

		Task Update(int id,
		            DTOStudent dto);

		Task Delete(int id);

		Task<DTOStudent> Get(int id);

		Task<List<DTOStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cd18ee6eb7d0661c8c83b3aa393279ac</Hash>
</Codenesium>*/