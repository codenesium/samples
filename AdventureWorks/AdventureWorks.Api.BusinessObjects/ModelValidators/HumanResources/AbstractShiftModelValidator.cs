using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractShiftModelValidator: AbstractValidator<ShiftModel>
	{
		public new ValidationResult Validate(ShiftModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ShiftModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x.StartTime).NotNull();
		}

		public virtual void EndTimeRules()
		{
			this.RuleFor(x => x.EndTime).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>427c76cef3b919fe5b74e52018ebe7cb</Hash>
</Codenesium>*/