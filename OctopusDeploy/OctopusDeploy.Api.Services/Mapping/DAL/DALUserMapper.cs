using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public partial class DALUserMapper : DALAbstractUserMapper, IDALUserMapper
        {
                public DALUserMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>47ead3c100d38a20be8d35e76ddcdb37</Hash>
</Codenesium>*/