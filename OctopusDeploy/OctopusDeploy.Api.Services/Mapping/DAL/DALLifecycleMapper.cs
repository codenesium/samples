using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALLifecycleMapper : DALAbstractLifecycleMapper, IDALLifecycleMapper
        {
                public DALLifecycleMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c4e9d7660654d80a51f834fa020c90c1</Hash>
</Codenesium>*/