using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALUserMapper
        {
                User MapBOToEF(
                        BOUser bo);

                BOUser MapEFToBO(
                        User efUser);

                List<BOUser> MapEFToBO(
                        List<User> records);
        }
}

/*<Codenesium>
    <Hash>f7a7d7db6f5b4a113b32698f13463391</Hash>
</Codenesium>*/