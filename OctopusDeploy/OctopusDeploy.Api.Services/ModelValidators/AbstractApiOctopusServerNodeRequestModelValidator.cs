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
        public abstract class AbstractApiOctopusServerNodeRequestModelValidator : AbstractValidator<ApiOctopusServerNodeRequestModel>
        {
                private string existingRecordId;

                private IOctopusServerNodeRepository octopusServerNodeRepository;

                public AbstractApiOctopusServerNodeRequestModelValidator(IOctopusServerNodeRepository octopusServerNodeRepository)
                {
                        this.octopusServerNodeRepository = octopusServerNodeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiOctopusServerNodeRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IsInMaintenanceModeRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void LastSeenRules()
                {
                }

                public virtual void MaxConcurrentTasksRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void RankRules()
                {
                        this.RuleFor(x => x.Rank).NotNull();
                        this.RuleFor(x => x.Rank).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>1ef30a3a103aa4808699b59651864f63</Hash>
</Codenesium>*/