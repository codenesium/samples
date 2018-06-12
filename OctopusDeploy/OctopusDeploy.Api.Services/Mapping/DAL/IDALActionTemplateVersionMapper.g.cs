using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALActionTemplateVersionMapper
        {
                ActionTemplateVersion MapBOToEF(
                        BOActionTemplateVersion bo);

                BOActionTemplateVersion MapEFToBO(
                        ActionTemplateVersion efActionTemplateVersion);

                List<BOActionTemplateVersion> MapEFToBO(
                        List<ActionTemplateVersion> records);
        }
}

/*<Codenesium>
    <Hash>0179f94629704189fba56a59b71db6e9</Hash>
</Codenesium>*/