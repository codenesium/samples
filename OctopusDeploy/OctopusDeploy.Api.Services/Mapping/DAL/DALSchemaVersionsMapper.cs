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
    <Hash>6518d5cdbd246d036c11cf8f6adc38fb</Hash>
</Codenesium>*/