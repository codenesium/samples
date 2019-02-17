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
		}

		public virtual void TeacherSkillIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7c9df01bec143a5f1f362c813bbf5490</Hash>
</Codenesium>*/