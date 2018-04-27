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
			this.EndDateRules();
			this.ModifiedDateRules();
			this.StandardCostRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductCostHistoryModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.StandardCostRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>dcc2496573cdbf4f57d6b4eed94958fd</Hash>
</Codenesium>*/