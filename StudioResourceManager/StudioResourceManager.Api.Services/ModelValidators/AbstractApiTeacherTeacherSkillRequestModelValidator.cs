using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiTeacherTeacherSkillRequestModelValidator : AbstractValidator<ApiTeacherTeacherSkillRequestModel>
	{
		private int existingRecordId;

		private ITeacherTeacherSkillRepository teacherTeacherSkillRepository;

		public AbstractApiTeacherTeacherSkillRequestModelValidator(ITeacherTeacherSkillRepository teacherTeacherSkillRepository)
		{
			this.teacherTeacherSkillRepository = teacherTeacherSkillRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherTeacherSkillRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TeacherSkillIdRules()
		{
			this.RuleFor(x => x.TeacherSkillId).MustAsync(this.BeValidTeacherSkillByTeacherSkillId).When(x => x?.TeacherSkillId != null).WithMessage("Invalid reference");
		}

		public virtual void IsDeletedRules()
		{
		}

		private async Task<bool> BeValidTeacherByTeacherId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teacherTeacherSkillRepository.TeacherByTeacherId(id);

			return record != null;
		}

		private async Task<bool> BeValidTeacherSkillByTeacherSkillId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.teacherTeacherSkillRepository.TeacherSkillByTeacherSkillId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>c60e0e2fc4720a674349c8bc4ff62c99</Hash>
</Codenesium>*/