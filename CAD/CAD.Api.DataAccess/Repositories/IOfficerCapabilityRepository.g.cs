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

		Task Delete(int capabilityId);

		Task<OfficerCapability> Get(int capabilityId);

		Task<List<OfficerCapability>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<OfficerCapability> OfficerCapabilityByCapabilityId(int capabilityId);

		Task<Officer> OfficerByOfficerId(int officerId);

		Task<List<OfficerCapability>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<OfficerCapability> CreateOfficerCapability(OfficerCapability item);

		Task DeleteOfficerCapability(OfficerCapability item);
	}
}

/*<Codenesium>
    <Hash>30e1625f7f1f092c551f65854ceb8cbb</Hash>
</Codenesium>*/