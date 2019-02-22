using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IOfficerRefCapabilityRepository
	{
		Task<OfficerRefCapability> Create(OfficerRefCapability item);

		Task Update(OfficerRefCapability item);

		Task Delete(int id);

		Task<OfficerRefCapability> Get(int id);

		Task<List<OfficerRefCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<OfficerCapability> OfficerCapabilityByCapabilityId(int capabilityId);

		Task<Officer> OfficerByOfficerId(int officerId);
	}
}

/*<Codenesium>
    <Hash>8bcbc0ddbdf786937980b5ed037ced40</Hash>
</Codenesium>*/