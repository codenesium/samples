using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiAdminServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3ce90ab84bb611955ed22cc324273007</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/