using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractRateModelValidator: AbstractValidator<RateModel>
	{
		public new ValidationResult Validate(RateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(RateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ITeacherSkillRepository TeacherSkillRepository { get; set; }
		public ITeacherRepository TeacherRepository { get; set; }
		public virtual void AmountPerMinuteRules()
		{
			this.RuleFor(x => x.AmountPerMinute).NotNull();
		}

		public virtual void TeacherSkillIdRules()
		{
			this.RuleFor(x => x.TeacherSkillId).NotNull();
			this.RuleFor(x => x.TeacherSkillId).Must(this.BeValidTeacherSkill).When(x => x ?.TeacherSkillId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).NotNull();
			this.RuleFor(x => x.TeacherId).Must(this.BeValidTeacher).When(x => x ?.TeacherId != null).WithMessage("Invalid reference");
		}

		private bool BeValidTeacherSkill(int id)
		{
			return this.TeacherSkillRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidTeacher(int id)
		{
			return this.TeacherRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>902b35780faff6f546f07d8e7ee7c5ae</Hash>
</Codenesium>*/