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
	public class ApiRowVersionCheckServerRequestModelValidator : AbstractValidator<ApiRowVersionCheckServerRequestModel>, IApiRowVersionCheckServerRequestModelValidator
	{
		private int existingRecordId;

		protected IRowVersionCheckRepository RowVersionCheckRepository { get; private set; }

		public ApiRowVersionCheckServerRequestModelValidator(IRowVersionCheckRepository rowVersionCheckRepository)
		{
			this.RowVersionCheckRepository = rowVersionCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRowVersionCheckServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckServerRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckServerRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowVersionRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c41310e8e152c0b1499ea26d4eccbbb2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/