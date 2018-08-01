using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiOrganizationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dcb8ed560ce8f816b97a8724fee6d666</Hash>
</Codenesium>*/