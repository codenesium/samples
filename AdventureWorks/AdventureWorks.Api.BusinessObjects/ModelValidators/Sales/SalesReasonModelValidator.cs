using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesReasonModelValidator: AbstractSalesReasonModelValidator, ISalesReasonModelValidator
	{
		public SalesReasonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesReasonModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ReasonTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesReasonModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ReasonTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>e9339bbaf4796cf98a5e574dd9b90105</Hash>
</Codenesium>*/