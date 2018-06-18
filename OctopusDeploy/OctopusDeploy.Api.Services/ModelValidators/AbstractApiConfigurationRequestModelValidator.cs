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
        public abstract class AbstractApiConfigurationRequestModelValidator: AbstractValidator<ApiConfigurationRequestModel>
        {
                private string existingRecordId;

                IConfigurationRepository configurationRepository;

                public AbstractApiConfigurationRequestModelValidator(IConfigurationRepository configurationRepository)
                {
                        this.configurationRepository = configurationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiConfigurationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>09232ee9f709c93a93817a115f471848</Hash>
</Codenesium>*/