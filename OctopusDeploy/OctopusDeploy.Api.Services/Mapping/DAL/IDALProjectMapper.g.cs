using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>4104c53515a01486744b5ca19b0a16d4</Hash>
</Codenesium>*/