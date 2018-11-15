using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiTeacherSkillServerRequestModelValidator : AbstractValidator<ApiTeacherSkillServerRequestModel>
	{
		private int existingRecordId;

		private ITeacherSkillRepository teacherSkillRepository;

		public AbstractApiTeacherSkillServerRequestModelValidator(ITeacherSkillRepository teacherSkillRepository)
		{
			this.teacherSkillRepository = teacherSkillRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTeacherSkillServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>0c385f94346bd7bb5181f1c40279d265</Hash>
</Codenesium>*/