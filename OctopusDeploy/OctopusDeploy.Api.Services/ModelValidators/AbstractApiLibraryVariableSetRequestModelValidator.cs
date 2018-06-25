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
        public abstract class AbstractApiLibraryVariableSetRequestModelValidator : AbstractValidator<ApiLibraryVariableSetRequestModel>
        {
                private string existingRecordId;

                private ILibraryVariableSetRepository libraryVariableSetRepository;

                public AbstractApiLibraryVariableSetRequestModelValidator(ILibraryVariableSetRepository libraryVariableSetRepository)
                {
                        this.libraryVariableSetRepository = libraryVariableSetRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiLibraryVariableSetRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLibraryVariableSetRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void VariableSetIdRules()
                {
                        this.RuleFor(x => x.VariableSetId).Length(0, 150);
                }

                private async Task<bool> BeUniqueByName(ApiLibraryVariableSetRequestModel model,  CancellationToken cancellationToken)
                {
                        LibraryVariableSet record = await this.libraryVariableSetRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>db2c6ab9bad3a817e43ab9b8771f3dff</Hash>
</Codenesium>*/