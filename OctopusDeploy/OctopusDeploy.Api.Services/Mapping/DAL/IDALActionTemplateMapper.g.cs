using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALActionTemplateMapper
        {
                ActionTemplate MapBOToEF(
                        BOActionTemplate bo);

                BOActionTemplate MapEFToBO(
                        ActionTemplate efActionTemplate);

                List<BOActionTemplate> MapEFToBO(
                        List<ActionTemplate> records);
        }
}

/*<Codenesium>
    <Hash>9d7368caecb1d89eb6f863709dba83a9</Hash>
</Codenesium>*/