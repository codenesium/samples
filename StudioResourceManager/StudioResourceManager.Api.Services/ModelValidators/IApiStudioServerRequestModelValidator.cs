using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiStudioServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudioServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ec657e55a296c54f951b01ad07dd9007</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/