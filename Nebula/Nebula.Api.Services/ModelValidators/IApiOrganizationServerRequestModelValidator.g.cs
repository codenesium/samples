using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiOrganizationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOrganizationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bc3ca8001d5d094bf31d6f3717a18b4c</Hash>
</Codenesium>*/