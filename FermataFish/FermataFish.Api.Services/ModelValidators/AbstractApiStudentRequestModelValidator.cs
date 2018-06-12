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
        public abstract class AbstractApiStudentRequestModelValidator: AbstractValidator<ApiStudentRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiStudentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiStudentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IFamilyRepository FamilyRepository { get; set; }

                public IStudioRepository StudioRepository { get; set; }

                public virtual void BirthdayRules()
                {
                        this.RuleFor(x => x.Birthday).NotNull();
                }

                public virtual void EmailRules()
                {
                        this.RuleFor(x => x.Email).NotNull();
                        this.RuleFor(x => x.Email).Length(0, 128);
                }

                public virtual void EmailRemindersEnabledRules()
                {
                        this.RuleFor(x => x.EmailRemindersEnabled).NotNull();
                }

                public virtual void FamilyIdRules()
                {
                        this.RuleFor(x => x.FamilyId).NotNull();
                        this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamily).When(x => x ?.FamilyId != null).WithMessage("Invalid reference");
                }

                public virtual void FirstNameRules()
                {
                        this.RuleFor(x => x.FirstName).NotNull();
                        this.RuleFor(x => x.FirstName).Length(0, 128);
                }

                public virtual void IsAdultRules()
                {
                        this.RuleFor(x => x.IsAdult).NotNull();
                }

                public virtual void LastNameRules()
                {
                        this.RuleFor(x => x.LastName).NotNull();
                        this.RuleFor(x => x.LastName).Length(0, 128);
                }

                public virtual void PhoneRules()
                {
                        this.RuleFor(x => x.Phone).NotNull();
                        this.RuleFor(x => x.Phone).Length(0, 128);
                }

                public virtual void SmsRemindersEnabledRules()
                {
                        this.RuleFor(x => x.SmsRemindersEnabled).NotNull();
                }

                public virtual void StudioIdRules()
                {
                        this.RuleFor(x => x.StudioId).NotNull();
                        this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidFamily(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.FamilyRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.StudioRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>9aacef7e8be6eae82e171a09a3c1d75c</Hash>
</Codenesium>*/