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
        public abstract class AbstractApiLibraryVariableSetRequestModelValidator: AbstractValidator<ApiLibraryVariableSetRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiLibraryVariableSetRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiLibraryVariableSetRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ILibraryVariableSetRepository LibraryVariableSetRepository { get; set; }
                public virtual void ContentTypeRules()
                {
                        this.RuleFor(x => x.ContentType).NotNull();
                        this.RuleFor(x => x.ContentType).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLibraryVariableSetRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void VariableSetIdRules()
                {
                        this.RuleFor(x => x.VariableSetId).Length(0, 150);
                }

                private async Task<bool> BeUniqueGetName(ApiLibraryVariableSetRequestModel model,  CancellationToken cancellationToken)
                {
                        LibraryVariableSet record = await this.LibraryVariableSetRepository.GetName(model.Name);

                        if (record == null || record.Id == this.existingRecordId)
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a380ed9a38e73a1e7bc4f59d8216765a</Hash>
</Codenesium>*/