using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IOrganizationRepository
	{
		Task<POCOOrganization> Create(ApiOrganizationModel model);

		Task Update(int id,
		            ApiOrganizationModel model);

		Task Delete(int id);

		Task<POCOOrganization> Get(int id);

		Task<List<POCOOrganization>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOOrganization> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>39609f36cff8e8780602922254191543</Hash>
</Codenesium>*/