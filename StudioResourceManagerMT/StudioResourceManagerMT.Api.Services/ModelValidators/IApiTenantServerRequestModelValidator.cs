using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTenantServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTenantServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTenantServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a3a7f3c5516d47167601db8f8b54ed9c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/