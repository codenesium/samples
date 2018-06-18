using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiOctopusServerNodeRequestModelValidator: AbstractValidator<ApiOctopusServerNodeRequestModel>
        {
                private string existingRecordId;

                IOctopusServerNodeRepository octopusServerNodeRepository;

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
    <Hash>c302b9a2c76d78bafecda1c37e5fe8e3</Hash>
</Codenesium>*/