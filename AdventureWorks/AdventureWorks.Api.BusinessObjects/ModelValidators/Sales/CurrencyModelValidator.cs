using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class CurrencyModelValidator: AbstractCurrencyModelValidator, ICurrencyModelValidator
	{
		public CurrencyModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(CurrencyModel model)
		{
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, CurrencyModel model)
		{
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>07df1657292b3be9d965367a5e76ad75</Hash>
</Codenesium>*/