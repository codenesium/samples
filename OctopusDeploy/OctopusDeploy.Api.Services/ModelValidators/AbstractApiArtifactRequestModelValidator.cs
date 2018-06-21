using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiArtifactRequestModelValidator : AbstractValidator<ApiArtifactRequestModel>
        {
                private string existingRecordId;

                private IArtifactRepository artifactRepository;

                public AbstractApiArtifactRequestModelValidator(IArtifactRepository artifactRepository)
                {
                        this.artifactRepository = artifactRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiArtifactRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CreatedRules()
                {
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void FilenameRules()
                {
                        this.RuleFor(x => x.Filename).NotNull();
                        this.RuleFor(x => x.Filename).Length(0, 200);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                        this.RuleFor(x => x.RelatedDocumentIds).NotNull();
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>ee1e69e4fd1e8265818fe5750469d816</Hash>
</Codenesium>*/