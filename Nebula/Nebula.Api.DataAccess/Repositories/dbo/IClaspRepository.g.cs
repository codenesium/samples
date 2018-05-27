using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		Task<DTOClasp> Create(DTOClasp dto);

		Task Update(int id,
		            DTOClasp dto);

		Task Delete(int id);

		Task<DTOClasp> Get(int id);

		Task<List<DTOClasp>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9f1266c6eb8ae5ed160e43a99f9dd299</Hash>
</Codenesium>*/