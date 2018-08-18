using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiAddressTypeRequestModelValidator : AbstractApiAddressTypeRequestModelValidator, IApiAddressTypeRequestModelValidator
	{
		public ApiAddressTypeRequestModelValidator(IAddressTypeRepository addressTypeRepository)
			: base(addressTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeRequestModel model)
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
    <Hash>de7b6010cf9b784dbd58775656fc14ae</Hash>
</Codenesium>*/