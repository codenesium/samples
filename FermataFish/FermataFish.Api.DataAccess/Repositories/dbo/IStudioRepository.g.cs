using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudioRepository
	{
		Task<DTOStudio> Create(DTOStudio dto);

		Task Update(int id,
		            DTOStudio dto);

		Task Delete(int id);

		Task<DTOStudio> Get(int id);

		Task<List<DTOStudio>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4d6092095cb42d7ed25fb3558b1e23f8</Hash>
</Codenesium>*/