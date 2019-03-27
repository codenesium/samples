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

		Task Delete(int id);

		Task<OfficerCapabilities> Get(int id);

		Task<List<OfficerCapabilities>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<OffCapability> OffCapabilityByCapabilityId(int capabilityId);

		Task<Officer> OfficerByOfficerId(int officerId);
	}
}

/*<Codenesium>
    <Hash>a2f64b8959f7790d70e6c473084560a3</Hash>
</Codenesium>*/