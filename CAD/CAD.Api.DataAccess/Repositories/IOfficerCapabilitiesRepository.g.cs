using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IOfficerCapabilitiesRepository
	{
		Task<OfficerCapabilities> Create(OfficerCapabilities item);

		Task Update(OfficerCapabilities item);

		Task Delete(int capabilityId);

		Task<OfficerCapabilities> Get(int capabilityId);

		Task<List<OfficerCapabilities>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Officer> OfficerByOfficerId(int officerId);
	}
}

/*<Codenesium>
    <Hash>b2d2921f2960c5e5fbd156696e59ca82</Hash>
</Codenesium>*/