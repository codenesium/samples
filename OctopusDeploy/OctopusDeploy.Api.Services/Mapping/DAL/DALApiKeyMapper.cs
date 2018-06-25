using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALApiKeyMapper : DALAbstractApiKeyMapper, IDALApiKeyMapper
        {
                public DALApiKeyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f5e9122ee8ef24191f75b648abaae5cc</Hash>
</Codenesium>*/