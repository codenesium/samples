using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractApiStudentXFamilyRequestModelValidator : AbstractValidator<ApiStudentXFamilyRequestModel>
        {
                private int existingRecordId;

                private IStudentXFamilyRepository studentXFamilyRepository;

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
                        this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamily).When(x => x?.FamilyId != null).WithMessage("Invalid reference");
                }

                public virtual void StudentIdRules()
                {
                        this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x?.StudentId != null).WithMessage("Invalid reference");
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
    <Hash>5877a22deba2ffc913cfec89cc5dbecb</Hash>
</Codenesium>*/