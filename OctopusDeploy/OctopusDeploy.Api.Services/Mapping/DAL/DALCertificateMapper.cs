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
    <Hash>ab2396fe2101c9873940208c939fcff6</Hash>
</Codenesium>*/