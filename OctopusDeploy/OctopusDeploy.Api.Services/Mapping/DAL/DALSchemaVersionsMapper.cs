using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALSchemaVersionsMapper: DALAbstractSchemaVersionsMapper, IDALSchemaVersionsMapper
        {
                public DALSchemaVersionsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>6e368e2dce8711c5a8f277e7aef78a12</Hash>
</Codenesium>*/