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
        public abstract class AbstractApiRateRequestModelValidator : AbstractValidator<ApiRateRequestModel>
        {
                private int existingRecordId;

                private IRateRepository rateRepository;

                public AbstractApiRateRequestModelValidator(IRateRepository rateRepository)
                {
                        this.rateRepository = rateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiRateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AmountPerMinuteRules()
                {
                }

                public virtual void TeacherIdRules()
                {
                        this.RuleFor(x => x.TeacherId).MustAsync(this.BeValidTeacher).When(x => x?.TeacherId != null).WithMessage("Invalid reference");
                }

                public virtual void TeacherSkillIdRules()
                {
                        this.RuleFor(x => x.TeacherSkillId).MustAsync(this.BeValidTeacherSkill).When(x => x?.TeacherSkillId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidTeacher(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.rateRepository.GetTeacher(id);

                        return record != null;
                }

                private async Task<bool> BeValidTeacherSkill(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.rateRepository.GetTeacherSkill(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>813049bbd7072efd95b68d40ac14e722</Hash>
</Codenesium>*/