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
	public abstract class AbstractApiRateServerRequestModelValidator : AbstractValidator<ApiRateServerRequestModel>
	{
		private int existingRecordId;

		protected IRateRepository RateRepository { get; private set; }

		public AbstractApiRateServerRequestModelValidator(IRateRepository rateRepository)
		{
			this.RateRepository = rateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRateServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AmountPerMinuteRules()
		{
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
			var record = await this.RateRepository.TeacherByTeacherId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTeacherSkillByTeacherSkillId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.RateRepository.TeacherSkillByTeacherSkillId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>60e533df70f760aa166395afa4c42d1d</Hash>
</Codenesium>*/