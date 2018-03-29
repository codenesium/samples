using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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
			RuleFor(x => x.ErrorTime).NotNull();
		}

		public virtual void UserNameRules()
		{
			RuleFor(x => x.UserName).NotNull();
			RuleFor(x => x.UserName).Length(0,128);
		}

		public virtual void ErrorNumberRules()
		{
			RuleFor(x => x.ErrorNumber).NotNull();
		}

		public virtual void ErrorSeverityRules()
		{                       }

		public virtual void ErrorStateRules()
		{                       }

		public virtual void ErrorProcedureRules()
		{
			RuleFor(x => x.ErrorProcedure).Length(0,126);
		}

		public virtual void ErrorLineRules()
		{                       }

		public virtual void ErrorMessageRules()
		{
			RuleFor(x => x.ErrorMessage).NotNull();
			RuleFor(x => x.ErrorMessage).Length(0,4000);
		}
	}
}

/*<Codenesium>
    <Hash>772036628696a3a07056250e7d6121b2</Hash>
</Codenesium>*/