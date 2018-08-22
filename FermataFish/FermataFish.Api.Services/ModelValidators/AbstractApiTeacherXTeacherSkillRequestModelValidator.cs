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
	public abstract class AbstractApiTeacherXTeacherSkillRequestModelValidator : AbstractValidator<ApiTeacherXTeacherSkillRequestModel>
	{
		private int existingRecordId;

		private ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository;

		public AbstractApiTeacherXTeacherSkillRequestModelValidator(ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository)
		{
			this.teacherXTeacherSkillRepository = teacherXTeacherSkillRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherXTeacherSkillRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).MustAsync(this.BeValidTeacher).When(x => x?.TeacherId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherSkillIdRules()
		{
			this.RuleFor(x => x.TeacherSkillId).MustAsync(this.BeValidTeacherSkill).When(x => x?.TeacherSkillId != null).WithMessage("Invalid reference");
		}

		public virtual void StudioIdRules()
		{
			this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTeacher(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teacherXTeacherSkillRepository.GetTeacher(id);

			return record != null;
		}

		private async Task<bool> BeValidTeacherSkill(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teacherXTeacherSkillRepository.GetTeacherSkill(id);

			return record != null;
		}

		private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teacherXTeacherSkillRepository.GetStudio(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a8c6514c92fde67fcdd0ef6404b4aed0</Hash>
</Codenesium>*/