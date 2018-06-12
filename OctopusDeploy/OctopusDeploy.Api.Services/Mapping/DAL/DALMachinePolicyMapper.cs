using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALMachinePolicyMapper: DALAbstractMachinePolicyMapper, IDALMachinePolicyMapper
        {
                public DALMachinePolicyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>93f4395f32c11f9129146e4a840ebbf8</Hash>
</Codenesium>*/