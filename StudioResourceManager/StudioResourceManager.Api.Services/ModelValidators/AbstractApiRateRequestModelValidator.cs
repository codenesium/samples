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
	public abstract class AbstractApiRateRequestModelValidator : AbstractValidator<ApiRateRequestModel>
	{
		private int existingRecordId;

		private IRateRepository rateRepository;

		public AbstractApiRateRequestModelValidator(IRateRepository rateRepository)
		{
			this.rateRepository = rateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRateRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AmountPerMinuteRules()
		{
		}

		public virtual void TeacherIdRules()
		{
			this.RuleFor(x => x.TeacherId).MustAsync(this.BeValidTeacherByTeacherId).When(x => x?.TeacherId != null).WithMessage("Invalid reference");
		}

		public virtual void TeacherSkillIdRules()
		{
			this.RuleFor(x => x.TeacherSkillId).MustAsync(this.BeValidTeacherSkillByTeacherSkillId).When(x => x?.TeacherSkillId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTeacherByTeacherId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.rateRepository.TeacherByTeacherId(id);

			return record != null;
		}

		private async Task<bool> BeValidTeacherSkillByTeacherSkillId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.rateRepository.TeacherSkillByTeacherSkillId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>6128182f329411325dd5c6534b9b58a4</Hash>
</Codenesium>*/