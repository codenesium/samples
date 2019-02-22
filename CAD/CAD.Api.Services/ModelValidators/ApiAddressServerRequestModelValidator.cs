using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiAddressServerRequestModelValidator : AbstractApiAddressServerRequestModelValidator, IApiAddressServerRequestModelValidator
	{
		public ApiAddressServerRequestModelValidator(IAddressRepository addressRepository)
			: base(addressRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateRules();
			this.ZipRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>1ec8c907f06327f7dc1e4b32118a9669</Hash>
</Codenesium>*/