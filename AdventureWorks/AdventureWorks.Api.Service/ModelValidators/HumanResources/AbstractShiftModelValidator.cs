using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void StartTimeRules()
		{
			RuleFor(x => x.StartTime).NotNull();
		}

		public virtual void EndTimeRules()
		{
			RuleFor(x => x.EndTime).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>e6d3455d76821d7b08e0228d0661c558</Hash>
</Codenesium>*/