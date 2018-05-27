using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		Task<DTOOrganization> Create(DTOOrganization dto);

		Task Update(int id,
		            DTOOrganization dto);

		Task Delete(int id);

		Task<DTOOrganization> Get(int id);

		Task<List<DTOOrganization>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOOrganization> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>d63365ad0da2bdf605c620d994c0e05a</Hash>
</Codenesium>*/