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
	public abstract class AbstractApiTeacherSkillRequestModelValidator : AbstractValidator<ApiTeacherSkillRequestModel>
	{
		private int existingRecordId;

		private ITeacherSkillRepository teacherSkillRepository;

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

		public virtual void IsDeletedRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a16cfc6c69b2e71c338bf5d786c0f98c</Hash>
</Codenesium>*/