using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiErrorLogServerRequestModelValidator : AbstractValidator<ApiErrorLogServerRequestModel>
	{
		private int existingRecordId;

		protected IErrorLogRepository ErrorLogRepository { get; private set; }

		public AbstractApiErrorLogServerRequestModelValidator(IErrorLogRepository errorLogRepository)
		{
			this.ErrorLogRepository = errorLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiErrorLogServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ErrorLineRules()
		{
		}

		public virtual void ErrorMessageRules()
		{
			this.RuleFor(x => x.ErrorMessage).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.ErrorMessage).Length(0, 4000).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ErrorNumberRules()
		{
		}

		public virtual void ErrorProcedureRules()
		{
			this.RuleFor(x => x.ErrorProcedure).Length(0, 126).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ErrorSeverityRules()
		{
		}

		public virtual void ErrorStateRules()
		{
		}

		public virtual void ErrorTimeRules()
		{
		}

		public virtual void UserNameRules()
		{
			this.RuleFor(x => x.UserName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.UserName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>d1c9d3fb97998f53643173f7a5d0b20c</Hash>
</Codenesium>*/