using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DALApiKeyMapper: DALAbstractApiKeyMapper, IDALApiKeyMapper
        {
                public DALApiKeyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b3e301f56e3a412dd788354764c830bc</Hash>
</Codenesium>*/