using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IApiEventServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fc20ee91473ec3fe9f6bf6345e043d97</Hash>
</Codenesium>*/