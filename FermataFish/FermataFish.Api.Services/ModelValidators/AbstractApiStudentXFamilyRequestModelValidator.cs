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

                IStudentXFamilyRepository studentXFamilyRepository;

                public AbstractApiStudentXFamilyRequestModelValidator(IStudentXFamilyRepository studentXFamilyRepository)
                {
                        this.studentXFamilyRepository = studentXFamilyRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiStudentXFamilyRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void FamilyIdRules()
                {
                        this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamily).When(x => x ?.FamilyId != null).WithMessage("Invalid reference");
                }

                public virtual void StudentIdRules()
                {
                        this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidFamily(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.studentXFamilyRepository.GetFamily(id);

                        return record != null;
                }

                private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.studentXFamilyRepository.GetStudent(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>0b50ea7df1e5193407a3f69389c16130</Hash>
</Codenesium>*/