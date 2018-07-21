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
        public abstract class AbstractApiVariableSetRequestModelValidator : AbstractValidator<ApiVariableSetRequestModel>
        {
                private string existingRecordId;

                private IVariableSetRepository variableSetRepository;

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
                }

                public virtual void OwnerIdRules()
                {
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
    <Hash>1568dafe54e6a07dc9d19e27176acf2b</Hash>
</Codenesium>*/