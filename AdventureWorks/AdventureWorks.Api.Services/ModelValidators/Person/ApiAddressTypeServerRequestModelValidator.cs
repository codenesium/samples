using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiAddressTypeServerRequestModelValidator : AbstractApiAddressTypeServerRequestModelValidator, IApiAddressTypeServerRequestModelValidator
	{
		public ApiAddressTypeServerRequestModelValidator(IAddressTypeRepository addressTypeRepository)
			: base(addressTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a195531028f9a2c10f3c78811cd4806d</Hash>
</Codenesium>*/