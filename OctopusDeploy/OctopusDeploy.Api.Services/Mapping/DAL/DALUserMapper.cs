using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALUserMapper : DALAbstractUserMapper, IDALUserMapper
	{
		public DALUserMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>b219aa0721c38e624a036dd486540270</Hash>
</Codenesium>*/