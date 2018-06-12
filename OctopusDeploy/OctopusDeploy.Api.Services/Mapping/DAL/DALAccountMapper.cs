using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALAccountMapper: DALAbstractAccountMapper, IDALAccountMapper
        {
                public DALAccountMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5d7941bbb18bb009ab4f1ce7a2583cf2</Hash>
</Codenesium>*/