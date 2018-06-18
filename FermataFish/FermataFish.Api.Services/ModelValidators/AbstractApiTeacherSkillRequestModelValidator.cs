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
        public abstract class AbstractApiTeacherSkillRequestModelValidator: AbstractValidator<ApiTeacherSkillRequestModel>
        {
                private int existingRecordId;

                ITeacherSkillRepository teacherSkillRepository;

                public AbstractApiTeacherSkillRequestModelValidator(ITeacherSkillRepository teacherSkillRepository)
                {
                        this.teacherSkillRepository = teacherSkillRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTeacherSkillRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void StudioIdRules()
                {
                        this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x ?.StudioId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.teacherSkillRepository.GetStudio(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>b71beb4f916fddfb718cbfa2197e771d</Hash>
</Codenesium>*/