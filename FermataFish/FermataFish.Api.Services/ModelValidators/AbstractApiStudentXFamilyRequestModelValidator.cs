using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services

{
        public abstract class AbstractApiStudentXFamilyRequestModelValidator: AbstractValidator<ApiStudentXFamilyRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiStudentXFamilyRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiStudentXFamilyRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IFamilyRepository FamilyRepository { get; set; }

                public IStudentRepository StudentRepository { get; set; }

                public virtual void FamilyIdRules()
                {
                        this.RuleFor(x => x.FamilyId).NotNull();
                        this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamily).When(x => x ?.FamilyId != null).WithMessage("Invalid reference");
                }

                public virtual void StudentIdRules()
                {
                        this.RuleFor(x => x.StudentId).NotNull();
                        this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidFamily(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.FamilyRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.StudentRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>c39638caad0dac0b9c47c604dee0a267</Hash>
</Codenesium>*/