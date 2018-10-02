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
	}
}

/*<Codenesium>
    <Hash>cdc189d3bd71a022c21a47f55e30ecd6</Hash>
</Codenesium>*/