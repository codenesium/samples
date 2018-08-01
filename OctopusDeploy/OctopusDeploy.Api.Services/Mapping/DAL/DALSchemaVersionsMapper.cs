using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
	public partial class DALSchemaVersionsMapper : DALAbstractSchemaVersionsMapper, IDALSchemaVersionsMapper
	{
		public DALSchemaVersionsMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>41c9e2d443bdd860ae90f307d6b6386b</Hash>
</Codenesium>*/