using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		Task<Organization> Create(Organization item);

		Task Update(Organization item);

		Task Delete(int id);

		Task<Organization> Get(int id);

		Task<List<Organization>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dd222293c785182cb6466756260c71a5</Hash>
</Codenesium>*/