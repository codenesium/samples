using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALLifecycleMapper: DALAbstractLifecycleMapper, IDALLifecycleMapper
        {
                public DALLifecycleMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>49f57b786d10b6be552658eb9ab87334</Hash>
</Codenesium>*/