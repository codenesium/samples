using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiEmployeeServerRequestModelValidator : AbstractApiEmployeeServerRequestModelValidator, IApiEmployeeServerRequestModelValidator
	{
		public ApiEmployeeServerRequestModelValidator(IEmployeeRepository employeeRepository)
			: base(employeeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeServerRequestModel model)
		{
			this.FirstNameRules();
			this.IsSalesPersonRules();
			this.IsShipperRules();
			this.LastNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeServerRequestModel model)
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
    <Hash>de34002eedfc55f0549ca011674ef733</Hash>
</Codenesium>*/