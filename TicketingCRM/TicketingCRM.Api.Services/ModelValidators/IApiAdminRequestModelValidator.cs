using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiAdminRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f337d942478a284bf718df4070b907a0</Hash>
</Codenesium>*/