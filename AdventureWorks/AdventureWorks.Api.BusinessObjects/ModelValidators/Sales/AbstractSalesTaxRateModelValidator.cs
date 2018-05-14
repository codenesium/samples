using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesTaxRateModelValidator: AbstractValidator<ApiSalesTaxRateModel>
	{
		public new ValidationResult Validate(ApiSalesTaxRateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTaxRateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x.StateProvinceID).NotNull();
		}

		public virtual void TaxRateRules()
		{
			this.RuleFor(x => x.TaxRate).NotNull();
		}

		public virtual void TaxTypeRules()
		{
			this.RuleFor(x => x.TaxType).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>39260c150dd55e012bb47f2960bbd33d</Hash>
</Codenesium>*/