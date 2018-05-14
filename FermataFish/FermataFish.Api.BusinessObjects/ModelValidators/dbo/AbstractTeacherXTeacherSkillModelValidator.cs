using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiTeacherXTeacherSkillModelValidator: AbstractValidator<ApiTeacherXTeacherSkillModel>
	{
		public new ValidationResult Validate(ApiTeacherXTeacherSkillModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherXTeacherSkillModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ITeacherRepository TeacherRepository { get; set; }
		public ITeacherSkillRepository TeacherSkillRepository { get; set; }
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
			return this.TeacherRepository.Get(id) != null;
		}

		private bool BeValidTeacherSkill(int id)
		{
			return this.TeacherSkillRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>0a2cd8d9fe217811498f07f5140d604d</Hash>
</Codenesium>*/