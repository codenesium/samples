using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPersonCreditCardModelValidator: AbstractApiPersonCreditCardModelValidator, IApiPersonCreditCardModelValidator
	{
		public ApiPersonCreditCardModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardModel model)
		{
			this.CreditCardIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardModel model)
		{
			this.CreditCardIDRules();
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
    <Hash>2df2ea57986f916b846c335af58b8313</Hash>
</Codenesium>*/