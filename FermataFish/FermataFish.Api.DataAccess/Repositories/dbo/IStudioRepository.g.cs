using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudioRepository
	{
		Task<POCOStudio> Create(ApiStudioModel model);

		Task Update(int id,
		            ApiStudioModel model);

		Task Delete(int id);

		Task<POCOStudio> Get(int id);

		Task<List<POCOStudio>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bc10f766713cb5c140402fd7f378de48</Hash>
</Codenesium>*/