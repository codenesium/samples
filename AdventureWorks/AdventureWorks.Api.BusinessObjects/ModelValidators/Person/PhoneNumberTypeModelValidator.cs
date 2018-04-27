using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class PhoneNumberTypeModelValidator: AbstractPhoneNumberTypeModelValidator, IPhoneNumberTypeModelValidator
	{
		public PhoneNumberTypeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PhoneNumberTypeModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PhoneNumberTypeModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>0f455a22090368ac6bc6bbdd5cbdf3bf</Hash>
</Codenesium>*/