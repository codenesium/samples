using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALProjectMapper
        {
                Project MapBOToEF(
                        BOProject bo);

                BOProject MapEFToBO(
                        Project efProject);

                List<BOProject> MapEFToBO(
                        List<Project> records);
        }
}

/*<Codenesium>
    <Hash>c3fecec8c971faedd4906cbec0fa5575</Hash>
</Codenesium>*/