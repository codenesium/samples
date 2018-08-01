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
	public abstract class AbstractApiTimestampCheckRequestModelValidator : AbstractValidator<ApiTimestampCheckRequestModel>
	{
		private int existingRecordId;

		private ITimestampCheckRepository timestampCheckRepository;

		public AbstractApiTimestampCheckRequestModelValidator(ITimestampCheckRepository timestampCheckRepository)
		{
			this.timestampCheckRepository = timestampCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTimestampCheckRequestModel model, int id)
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
    <Hash>7bc1072416ab8094b376c067adb81772</Hash>
</Codenesium>*/