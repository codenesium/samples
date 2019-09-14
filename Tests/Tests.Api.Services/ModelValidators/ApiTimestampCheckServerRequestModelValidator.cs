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
	public class ApiTimestampCheckServerRequestModelValidator : AbstractValidator<ApiTimestampCheckServerRequestModel>, IApiTimestampCheckServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITimestampCheckRepository TimestampCheckRepository { get; private set; }

		public ApiTimestampCheckServerRequestModelValidator(ITimestampCheckRepository timestampCheckRepository)
		{
			this.TimestampCheckRepository = timestampCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTimestampCheckServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTimestampCheckServerRequestModel model)
		{
			this.NameRules();
			this.TimestampRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTimestampCheckServerRequestModel model)
		{
			this.NameRules();
			this.TimestampRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>6ffda463388eb2736d91d3593fe98500</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/