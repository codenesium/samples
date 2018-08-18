using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiProvinceRequestModelValidator : AbstractApiProvinceRequestModelValidator, IApiProvinceRequestModelValidator
	{
		public ApiProvinceRequestModelValidator(IProvinceRepository provinceRepository)
			: base(provinceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProvinceRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProvinceRequestModel model)
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
    <Hash>3f290834a19c4fe6786d67c1b731dc72</Hash>
</Codenesium>*/