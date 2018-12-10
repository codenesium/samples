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
    <Hash>36d1a7f0c2f5bb69034181858b9880d2</Hash>
</Codenesium>*/