using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		Task<DTOLinkLog> Create(DTOLinkLog dto);

		Task Update(int id,
		            DTOLinkLog dto);

		Task Delete(int id);

		Task<DTOLinkLog> Get(int id);

		Task<List<DTOLinkLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b94fb351257ccf552a8a17b7e318f848</Hash>
</Codenesium>*/