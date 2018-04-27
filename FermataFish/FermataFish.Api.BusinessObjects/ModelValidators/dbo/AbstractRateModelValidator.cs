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

		public ITeacherRepository TeacherRepository { get; set; }
		public ITeacherSkillRepository TeacherSkillRepository { get; set; }
		public virtual void AmountPerMinuteRules()
		{
			this.RuleFor(x => x.AmountPerMinute).NotNull();
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).NotNull();
			this.RuleFor(x => x.TeacherId).Must(this.BeValidTeacher).When(x => x ?.TeacherId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherSkillIdRules()
		{
			this.RuleFor(x => x.TeacherSkillId).NotNull();
			this.RuleFor(x => x.TeacherSkillId).Must(this.BeValidTeacherSkill).When(x => x ?.TeacherSkillId != null).WithMessage("Invalid reference");
		}

		private bool BeValidTeacher(int id)
		{
			return this.TeacherRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidTeacherSkill(int id)
		{
			return this.TeacherSkillRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>16a2e22c71f3b181bdc81b32a052e9d2</Hash>
</Codenesium>*/