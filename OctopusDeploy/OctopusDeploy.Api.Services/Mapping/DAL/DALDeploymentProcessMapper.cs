using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALDeploymentProcessMapper: DALAbstractDeploymentProcessMapper, IDALDeploymentProcessMapper
        {
                public DALDeploymentProcessMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>50601a7bed7b920eacf7b49005507a62</Hash>
</Codenesium>*/