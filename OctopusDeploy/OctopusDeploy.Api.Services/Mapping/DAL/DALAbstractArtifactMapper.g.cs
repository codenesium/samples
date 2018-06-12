using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractArtifactMapper
        {
                public virtual Artifact MapBOToEF(
                        BOArtifact bo)
                {
                        Artifact efArtifact = new Artifact();

                        efArtifact.SetProperties(
                                bo.Created,
                                bo.EnvironmentId,
                                bo.Filename,
                                bo.Id,
                                bo.JSON,
                                bo.ProjectId,
                                bo.RelatedDocumentIds,
                                bo.TenantId);
                        return efArtifact;
                }

                public virtual BOArtifact MapEFToBO(
                        Artifact ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOArtifact();

                        bo.SetProperties(
                                ef.Id,
                                ef.Created,
                                ef.EnvironmentId,
                                ef.Filename,
                                ef.JSON,
                                ef.ProjectId,
                                ef.RelatedDocumentIds,
                                ef.TenantId);
                        return bo;
                }

                public virtual List<BOArtifact> MapEFToBO(
                        List<Artifact> records)
                {
                        List<BOArtifact> response = new List<BOArtifact>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e377e1fd287748e835868b77fa69c1ab</Hash>
</Codenesium>*/