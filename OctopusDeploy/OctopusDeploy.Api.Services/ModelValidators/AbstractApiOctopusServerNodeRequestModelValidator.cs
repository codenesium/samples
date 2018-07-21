using Codenesium.DataConversionExtensions;
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
                }

                public virtual void LastSeenRules()
                {
                }

                public virtual void MaxConcurrentTasksRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void RankRules()
                {
                        this.RuleFor(x => x.Rank).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>b95fd5b9dee361f14e395ef59dc92b53</Hash>
</Codenesium>*/