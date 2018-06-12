using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALMutexMapper: DALAbstractMutexMapper, IDALMutexMapper
        {
                public DALMutexMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>4fd98039a30fd68b2b2a209eafabb110</Hash>
</Codenesium>*/