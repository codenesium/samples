using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainStatusRepository
	{
		Task<POCOChainStatus> Create(ApiChainStatusModel model);

		Task Update(int id,
		            ApiChainStatusModel model);

		Task Delete(int id);

		Task<POCOChainStatus> Get(int id);

		Task<List<POCOChainStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOChainStatus> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>74dedc46677c71bbd04470ea0e29603b</Hash>
</Codenesium>*/