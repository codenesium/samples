using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiTimestampCheckServerRequestModelValidator : AbstractValidator<ApiTimestampCheckServerRequestModel>
	{
		private int existingRecordId;

		protected ITimestampCheckRepository TimestampCheckRepository { get; private set; }

		public AbstractApiTimestampCheckServerRequestModelValidator(ITimestampCheckRepository timestampCheckRepository)
		{
			this.TimestampCheckRepository = timestampCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTimestampCheckServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TimestampRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c5260b68e043cc151000cfbb582f1b6f</Hash>
</Codenesium>*/