using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IOfficerCapabilityRepository
	{
		Task<OfficerCapability> Create(OfficerCapability item);

		Task Update(OfficerCapability item);

		Task Delete(int id);

		Task<OfficerCapability> Get(int id);

		Task<List<OfficerCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<OfficerRefCapability>> OfficerRefCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1605e4577c3c9f676bc79006b7007ceb</Hash>
</Codenesium>*/