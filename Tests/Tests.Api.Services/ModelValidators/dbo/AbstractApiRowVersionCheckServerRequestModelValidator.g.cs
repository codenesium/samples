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
	public abstract class AbstractApiRowVersionCheckServerRequestModelValidator : AbstractValidator<ApiRowVersionCheckServerRequestModel>
	{
		private int existingRecordId;

		protected IRowVersionCheckRepository RowVersionCheckRepository { get; private set; }

		public AbstractApiRowVersionCheckServerRequestModelValidator(IRowVersionCheckRepository rowVersionCheckRepository)
		{
			this.RowVersionCheckRepository = rowVersionCheckRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRowVersionCheckServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>b1b5d0ffb36b8c982a3cef3af42ae3b5</Hash>
</Codenesium>*/