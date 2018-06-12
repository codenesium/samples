using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALArtifactMapper
        {
                Artifact MapBOToEF(
                        BOArtifact bo);

                BOArtifact MapEFToBO(
                        Artifact efArtifact);

                List<BOArtifact> MapEFToBO(
                        List<Artifact> records);
        }
}

/*<Codenesium>
    <Hash>983cd91c24ff86bca45758b8586dc7ed</Hash>
</Codenesium>*/