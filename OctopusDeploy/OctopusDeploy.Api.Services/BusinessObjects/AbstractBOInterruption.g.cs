using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOInterruption : AbstractBusinessObject
        {
                public AbstractBOInterruption()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  DateTimeOffset created,
                                                  string environmentId,
                                                  string jSON,
                                                  string projectId,
                                                  string relatedDocumentIds,
                                                  string responsibleTeamIds,
                                                  string status,
                                                  string taskId,
                                                  string tenantId,
                                                  string title)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.ResponsibleTeamIds = responsibleTeamIds;
                        this.Status = status;
                        this.TaskId = taskId;
                        this.TenantId = tenantId;
                        this.Title = title;
                }

                public DateTimeOffset Created { get; private set; }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string ResponsibleTeamIds { get; private set; }

                public string Status { get; private set; }

                public string TaskId { get; private set; }

                public string TenantId { get; private set; }

                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ba152fa853f7509f54c9467bc96ae660</Hash>
</Codenesium>*/