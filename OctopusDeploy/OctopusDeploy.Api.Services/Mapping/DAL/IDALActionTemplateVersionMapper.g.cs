using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>54cbd3a3632b9f6a65eb14cf6819cd27</Hash>
</Codenesium>*/