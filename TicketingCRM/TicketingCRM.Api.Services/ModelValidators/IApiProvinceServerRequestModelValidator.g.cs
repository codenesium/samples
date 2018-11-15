using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiProvinceServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProvinceServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProvinceServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d655e73e84294fbbb83cbb67af49672b</Hash>
</Codenesium>*/