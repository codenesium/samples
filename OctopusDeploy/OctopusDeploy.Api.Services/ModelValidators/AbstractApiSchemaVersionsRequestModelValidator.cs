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

                ISchemaVersionsRepository schemaVersionsRepository;

                public AbstractApiSchemaVersionsRequestModelValidator(ISchemaVersionsRepository schemaVersionsRepository)
                {
                        this.schemaVersionsRepository = schemaVersionsRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSchemaVersionsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AppliedRules()
                {
                }

                public virtual void ScriptNameRules()
                {
                        this.RuleFor(x => x.ScriptName).NotNull();
                        this.RuleFor(x => x.ScriptName).Length(0, 255);
                }
        }
}

/*<Codenesium>
    <Hash>893f0c6362177ea1f22eb297329a12fc</Hash>
</Codenesium>*/