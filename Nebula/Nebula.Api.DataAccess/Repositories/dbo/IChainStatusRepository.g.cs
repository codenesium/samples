using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainStatusRepository
	{
		Task<DTOChainStatus> Create(DTOChainStatus dto);

		Task Update(int id,
		            DTOChainStatus dto);

		Task Delete(int id);

		Task<DTOChainStatus> Get(int id);

		Task<List<DTOChainStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOChainStatus> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>d49b213f68a1bd0ce7198e19c883a884</Hash>
</Codenesium>*/