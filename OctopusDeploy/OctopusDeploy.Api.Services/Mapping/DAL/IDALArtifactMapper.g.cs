using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c19c975b5790622f27902eacd68d0dd6</Hash>
</Codenesium>*/