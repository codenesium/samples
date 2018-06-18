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
        public abstract class AbstractApiVariableSetRequestModelValidator: AbstractValidator<ApiVariableSetRequestModel>
        {
                private string existingRecordId;

                IVariableSetRepository variableSetRepository;

                public AbstractApiVariableSetRequestModelValidator(IVariableSetRepository variableSetRepository)
                {
                        this.variableSetRepository = variableSetRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiVariableSetRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IsFrozenRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void OwnerIdRules()
                {
                        this.RuleFor(x => x.OwnerId).NotNull();
                        this.RuleFor(x => x.OwnerId).Length(0, 150);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                }

                public virtual void VersionRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>cf8eb0c09beffc2683fa6b0445eb1ab3</Hash>
</Codenesium>*/