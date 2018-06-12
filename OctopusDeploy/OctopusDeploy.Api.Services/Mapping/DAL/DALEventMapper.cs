using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALEventMapper: DALAbstractEventMapper, IDALEventMapper
        {
                public DALEventMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>376f06c9adbdbc6e005b86dc92f84c45</Hash>
</Codenesium>*/