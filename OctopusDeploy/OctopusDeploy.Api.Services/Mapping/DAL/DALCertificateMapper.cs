using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALCertificateMapper : DALAbstractCertificateMapper, IDALCertificateMapper
	{
		public DALCertificateMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8da4d70fe2f14c535cb637842b62e582</Hash>
</Codenesium>*/