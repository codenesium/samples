using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>996f53b4d29c7b4e707d8ba416813760</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/