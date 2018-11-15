using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>b8de09a992ec0da82afbacc637ced6ce</Hash>
</Codenesium>*/