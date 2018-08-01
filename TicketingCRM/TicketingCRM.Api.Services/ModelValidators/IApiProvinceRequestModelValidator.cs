using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public interface IApiProvinceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProvinceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProvinceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7461f7b122279286bc7922f018010927</Hash>
</Codenesium>*/