using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiEmployeeRequestModelValidator: AbstractApiEmployeeRequestModelValidator, IApiEmployeeRequestModelValidator
	{
		public ApiEmployeeRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>72ac13712eabe389350c0ee135be1111</Hash>
</Codenesium>*/