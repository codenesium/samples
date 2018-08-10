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
    <Hash>1849ebcc0a5395abb3a18f381bc37cd5</Hash>
</Codenesium>*/