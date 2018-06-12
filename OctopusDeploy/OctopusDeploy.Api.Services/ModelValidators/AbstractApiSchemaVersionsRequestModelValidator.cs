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
        public abstract class AbstractApiSchemaVersionsRequestModelValidator: AbstractValidator<ApiSchemaVersionsRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSchemaVersionsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSchemaVersionsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AppliedRules()
                {
                        this.RuleFor(x => x.Applied).NotNull();
                }

                public virtual void ScriptNameRules()
                {
                        this.RuleFor(x => x.ScriptName).NotNull();
                        this.RuleFor(x => x.ScriptName).Length(0, 255);
                }
        }
}

/*<Codenesium>
    <Hash>3cfd427a1bdc7773e0b9779a0fba380c</Hash>
</Codenesium>*/