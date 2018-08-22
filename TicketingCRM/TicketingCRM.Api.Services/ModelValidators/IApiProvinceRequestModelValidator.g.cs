using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiProvinceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProvinceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProvinceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>379a534db47cf3372e73a3e7b979e2cc</Hash>
</Codenesium>*/