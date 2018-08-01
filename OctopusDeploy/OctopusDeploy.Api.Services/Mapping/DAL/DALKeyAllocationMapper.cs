using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALKeyAllocationMapper : DALAbstractKeyAllocationMapper, IDALKeyAllocationMapper
	{
		public DALKeyAllocationMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>48ba3251c79a239b91ac4f7d83106640</Hash>
</Codenesium>*/