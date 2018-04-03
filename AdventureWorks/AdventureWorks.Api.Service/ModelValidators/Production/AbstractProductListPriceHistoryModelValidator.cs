using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductListPriceHistoryModelValidator: AbstractValidator<ProductListPriceHistoryModel>
	{
		public new ValidationResult Validate(ProductListPriceHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductListPriceHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ListPriceRules()
		{
			RuleFor(x => x.ListPrice).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>07b5b665dac777342a016adf16dfe2e3</Hash>
</Codenesium>*/