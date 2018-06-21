using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>9ab326f2cee744efcffd728c9ff5b26d</Hash>
</Codenesium>*/