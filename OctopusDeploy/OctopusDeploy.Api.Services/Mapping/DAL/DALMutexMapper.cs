using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALMutexMapper : DALAbstractMutexMapper, IDALMutexMapper
        {
                public DALMutexMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>effae4fccfa4b0022211fe5656516532</Hash>
</Codenesium>*/