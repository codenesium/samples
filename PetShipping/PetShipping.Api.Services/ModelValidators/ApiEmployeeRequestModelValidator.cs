using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiEmployeeRequestModelValidator : AbstractApiEmployeeRequestModelValidator, IApiEmployeeRequestModelValidator
	{
		public ApiEmployeeRequestModelValidator(IEmployeeRepository employeeRepository)
			: base(employeeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model)
		{
			this.FirstNameRules();
			this.IsSalesPersonRules();
			this.IsShipperRules();
			this.LastNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model)
		{
			this.FirstNameRules();
			this.IsSalesPersonRules();
			this.IsShipperRules();
			this.LastNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>febd0e04055d7d321d2deaa615778026</Hash>
</Codenesium>*/