using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesTaxRateModelValidator: AbstractSalesTaxRateModelValidator, ISalesTaxRateModelValidator
	{
		public SalesTaxRateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesTaxRateModel model)
		{
			this.StateProvinceIDRules();
			this.TaxTypeRules();
			this.TaxRateRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesTaxRateModel model)
		{
			this.StateProvinceIDRules();
			this.TaxTypeRules();
			this.TaxRateRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>6dd98f3a547831ad257cd53d1f95771e</Hash>
</Codenesium>*/