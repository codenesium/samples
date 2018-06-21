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
        public abstract class AbstractApiSchemaVersionsRequestModelValidator : AbstractValidator<ApiSchemaVersionsRequestModel>
        {
                private int existingRecordId;

                private ISchemaVersionsRepository schemaVersionsRepository;

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
    <Hash>83af627e89d9ea5ea74195c4861e4e16</Hash>
</Codenesium>*/