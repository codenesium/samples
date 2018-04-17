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
			this.NameRules();
			this.ReasonTypeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesReasonModel model)
		{
			this.NameRules();
			this.ReasonTypeRules();
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
    <Hash>66475a2b665a180e8d5ff0a0d2088068</Hash>
</Codenesium>*/