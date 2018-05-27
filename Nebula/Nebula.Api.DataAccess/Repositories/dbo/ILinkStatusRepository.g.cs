using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		Task<DTOLinkStatus> Create(DTOLinkStatus dto);

		Task Update(int id,
		            DTOLinkStatus dto);

		Task Delete(int id);

		Task<DTOLinkStatus> Get(int id);

		Task<List<DTOLinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOLinkStatus> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>53dd0df8aa2761b748b51c6b0e56b2eb</Hash>
</Codenesium>*/