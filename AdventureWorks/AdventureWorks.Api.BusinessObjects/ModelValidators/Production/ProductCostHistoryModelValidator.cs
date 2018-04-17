using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductCostHistoryModelValidator: AbstractProductCostHistoryModelValidator, IProductCostHistoryModelValidator
	{
		public ProductCostHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductCostHistoryModel model)
		{
			this.StartDateRules();
			this.EndDateRules();
			this.StandardCostRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductCostHistoryModel model)
		{
			this.StartDateRules();
			this.EndDateRules();
			this.StandardCostRules();
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
    <Hash>99e17ff7ff703f45bed84907df9a5ee0</Hash>
</Codenesium>*/