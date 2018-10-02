using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface ISysdiagramRepository
	{
		Task<Sysdiagram> Create(Sysdiagram item);

		Task Update(Sysdiagram item);

		Task Delete(int diagramId);

		Task<Sysdiagram> Get(int diagramId);

		Task<List<Sysdiagram>> All(int limit = int.MaxValue, int offset = 0);

		Task<Sysdiagram> ByPrincipalIdName(int principalId, string name);
	}
}

/*<Codenesium>
    <Hash>a9dbc2fd1069d828a6713f7a6ab90c0a</Hash>
</Codenesium>*/