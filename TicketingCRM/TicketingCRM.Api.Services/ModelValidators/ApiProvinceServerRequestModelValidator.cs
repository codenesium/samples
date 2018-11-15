using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiProvinceServerRequestModelValidator : AbstractApiProvinceServerRequestModelValidator, IApiProvinceServerRequestModelValidator
	{
		public ApiProvinceServerRequestModelValidator(IProvinceRepository provinceRepository)
			: base(provinceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProvinceServerRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProvinceServerRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>040190b9c624cabe3e71f40c2cd9b33b</Hash>
</Codenesium>*/