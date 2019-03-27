using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiTeacherTeacherSkillServerRequestModelValidator : AbstractValidator<ApiTeacherTeacherSkillServerRequestModel>
	{
		private int existingRecordId;

		protected ITeacherTeacherSkillRepository TeacherTeacherSkillRepository { get; private set; }

		public AbstractApiTeacherTeacherSkillServerRequestModelValidator(ITeacherTeacherSkillRepository teacherTeacherSkillRepository)
		{
			this.TeacherTeacherSkillRepository = teacherTeacherSkillRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherTeacherSkillServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TeacherSkillIdRules()
		{
			this.RuleFor(x => x.TeacherSkillId).MustAsync(this.BeValidTeacherSkillByTeacherSkillId).When(x => !x?.TeacherSkillId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidTeacherByTeacherId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TeacherTeacherSkillRepository.TeacherByTeacherId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTeacherSkillByTeacherSkillId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TeacherTeacherSkillRepository.TeacherSkillByTeacherSkillId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>3473aa7d4acb78526f387a7548c84fa7</Hash>
</Codenesium>*/