using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IOffCapabilityRepository
	{
		Task<OffCapability> Create(OffCapability item);

		Task Update(OffCapability item);

		Task Delete(int id);

		Task<OffCapability> Get(int id);

		Task<List<OffCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<OfficerCapabilities>> OfficerCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bca73ca3873bc036686bf4e034b8c751</Hash>
</Codenesium>*/