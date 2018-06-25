using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALMutexMapper : DALAbstractMutexMapper, IDALMutexMapper
        {
                public DALMutexMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>6a452e5cd4d53f324a0945f617586b0b</Hash>
</Codenesium>*/