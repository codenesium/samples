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
	public class ApiTeacherTeacherSkillServerRequestModelValidator : AbstractValidator<ApiTeacherTeacherSkillServerRequestModel>, IApiTeacherTeacherSkillServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITeacherTeacherSkillRepository TeacherTeacherSkillRepository { get; private set; }

		public ApiTeacherTeacherSkillServerRequestModelValidator(ITeacherTeacherSkillRepository teacherTeacherSkillRepository)
		{
			this.TeacherTeacherSkillRepository = teacherTeacherSkillRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherTeacherSkillServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherTeacherSkillServerRequestModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherTeacherSkillServerRequestModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).MustAsync(this.BeValidTeacherByTeacherId).When(x => !x?.TeacherId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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
    <Hash>eb52e459f895a34a44925fa055ca50bc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/