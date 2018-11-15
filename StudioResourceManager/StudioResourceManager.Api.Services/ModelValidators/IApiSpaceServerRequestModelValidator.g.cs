using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiSpaceServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f307c01d02800ba40e06e76594b23c00</Hash>
</Codenesium>*/