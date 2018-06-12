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
        public abstract class AbstractApiExtensionConfigurationRequestModelValidator: AbstractValidator<ApiExtensionConfigurationRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiExtensionConfigurationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiExtensionConfigurationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ExtensionAuthorRules()
                {
                        this.RuleFor(x => x.ExtensionAuthor).Length(0, 1000);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 1000);
                }
        }
}

/*<Codenesium>
    <Hash>f72231d8203790759c81f834032f6f80</Hash>
</Codenesium>*/