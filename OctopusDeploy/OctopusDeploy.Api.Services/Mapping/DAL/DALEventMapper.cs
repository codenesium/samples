using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALEventMapper : DALAbstractEventMapper, IDALEventMapper
	{
		public DALEventMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>98c58628d27fb94bb844b816cc16044d</Hash>
</Codenesium>*/