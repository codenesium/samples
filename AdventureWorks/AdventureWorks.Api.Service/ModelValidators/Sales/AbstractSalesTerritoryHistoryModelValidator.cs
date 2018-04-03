using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesTerritoryHistoryModelValidator: AbstractValidator<SalesTerritoryHistoryModel>
	{
		public new ValidationResult Validate(SalesTerritoryHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesTerritoryHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void TerritoryIDRules()
		{
			RuleFor(x => x.TerritoryID).NotNull();
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>1f8829023e6bd4882d1a27fe7ce56452</Hash>
</Codenesium>*/