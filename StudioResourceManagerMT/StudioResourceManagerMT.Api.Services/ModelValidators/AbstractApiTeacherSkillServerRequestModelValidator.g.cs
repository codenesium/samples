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
	public abstract class AbstractApiTeacherSkillServerRequestModelValidator : AbstractValidator<ApiTeacherSkillServerRequestModel>
	{
		private int existingRecordId;

		protected ITeacherSkillRepository TeacherSkillRepository { get; private set; }

		public AbstractApiTeacherSkillServerRequestModelValidator(ITeacherSkillRepository teacherSkillRepository)
		{
			this.TeacherSkillRepository = teacherSkillRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherSkillServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>6ccb0f71ebcf903c028954ab24b78c2a</Hash>
</Codenesium>*/