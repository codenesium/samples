using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainRepository
	{
		Task<DTOChain> Create(DTOChain dto);

		Task Update(int id,
		            DTOChain dto);

		Task Delete(int id);

		Task<DTOChain> Get(int id);

		Task<List<DTOChain>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOChain> GetExternalId(Guid externalId);
	}
}

/*<Codenesium>
    <Hash>edc3821b87ec2b279ea06effd68a4f55</Hash>
</Codenesium>*/