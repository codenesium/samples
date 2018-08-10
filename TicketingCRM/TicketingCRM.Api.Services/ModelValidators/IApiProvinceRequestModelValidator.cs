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
    <Hash>652d5d7370ebed8795e24cf19cf9c068</Hash>
</Codenesium>*/