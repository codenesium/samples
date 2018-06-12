using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALOctopusServerNodeMapper: DALAbstractOctopusServerNodeMapper, IDALOctopusServerNodeMapper
        {
                public DALOctopusServerNodeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d4c5a4187c02bbd76e111bc943bbdadb</Hash>
</Codenesium>*/