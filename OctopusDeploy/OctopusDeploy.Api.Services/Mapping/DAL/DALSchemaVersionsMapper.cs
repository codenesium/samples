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
    <Hash>198d9ec546ab0dba7efd244880db5cd0</Hash>
</Codenesium>*/