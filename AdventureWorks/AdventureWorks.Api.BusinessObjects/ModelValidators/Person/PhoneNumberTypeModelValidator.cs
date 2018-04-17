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
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PhoneNumberTypeModel model)
		{
			this.NameRules();
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
    <Hash>74410f3648777e19be0f3e704019e99c</Hash>
</Codenesium>*/