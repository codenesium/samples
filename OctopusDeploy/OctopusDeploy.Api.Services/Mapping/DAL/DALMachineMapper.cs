using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALMachineMapper: DALAbstractMachineMapper, IDALMachineMapper
        {
                public DALMachineMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>052ff4c87e3d5f13cde327f9ffe96b49</Hash>
</Codenesium>*/