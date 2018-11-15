using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiTimestampCheckServerRequestModelValidator : AbstractValidator<ApiTimestampCheckServerRequestModel>
	{
		private int existingRecordId;

		private ITimestampCheckRepository timestampCheckRepository;

		public AbstractApiTimestampCheckServerRequestModelValidator(ITimestampCheckRepository timestampCheckRepository)
		{
			this.timestampCheckRepository = timestampCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTimestampCheckServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void TimestampRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>52ecca1aad63193e7a534b3855b47a6e</Hash>
</Codenesium>*/