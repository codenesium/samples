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
    <Hash>4df6be2498267e1e66ee6dfccbffab03</Hash>
</Codenesium>*/