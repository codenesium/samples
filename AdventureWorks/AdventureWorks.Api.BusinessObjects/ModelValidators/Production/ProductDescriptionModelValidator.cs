using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductDescriptionModelValidator: AbstractProductDescriptionModelValidator, IProductDescriptionModelValidator
	{
		public ProductDescriptionModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductDescriptionModel model)
		{
			this.DescriptionRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductDescriptionModel model)
		{
			this.DescriptionRules();
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
    <Hash>38541920421b60c16d3378b9f5200891</Hash>
</Codenesium>*/