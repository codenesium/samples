using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ApiSaleServerRequestModelValidator : AbstractApiSaleServerRequestModelValidator, IApiSaleServerRequestModelValidator
	{
		public ApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
			: base(saleRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model)
		{
			this.CustomerIdRules();
			this.DateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
		{
			this.CustomerIdRules();
			this.DateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>3a1fe1fc3f62f7edb8c584f04e2b3580</Hash>
</Codenesium>*/