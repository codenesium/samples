using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractErrorLogModelValidator: AbstractValidator<ErrorLogModel>
	{
		public new ValidationResult Validate(ErrorLogModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ErrorLogModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ErrorTimeRules()
		{
			this.RuleFor(x => x.ErrorTime).NotNull();
		}

		public virtual void UserNameRules()
		{
			this.RuleFor(x => x.UserName).NotNull();
			this.RuleFor(x => x.UserName).Length(0, 128);
		}

		public virtual void ErrorNumberRules()
		{
			this.RuleFor(x => x.ErrorNumber).NotNull();
		}

		public virtual void ErrorSeverityRules()
		{                       }

		public virtual void ErrorStateRules()
		{                       }

		public virtual void ErrorProcedureRules()
		{
			this.RuleFor(x => x.ErrorProcedure).Length(0, 126);
		}

		public virtual void ErrorLineRules()
		{                       }

		public virtual void ErrorMessageRules()
		{
			this.RuleFor(x => x.ErrorMessage).NotNull();
			this.RuleFor(x => x.ErrorMessage).Length(0, 4000);
		}
	}
}

/*<Codenesium>
    <Hash>19954ccc792128a214698ecceb9dc7c9</Hash>
</Codenesium>*/