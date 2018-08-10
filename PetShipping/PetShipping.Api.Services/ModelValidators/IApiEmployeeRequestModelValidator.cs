using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiEmployeeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>92507f9af7c009aa646a5742b888c9c8</Hash>
</Codenesium>*/