using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiOrganizationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b7349bb77e809a261724bc3e09552c88</Hash>
</Codenesium>*/