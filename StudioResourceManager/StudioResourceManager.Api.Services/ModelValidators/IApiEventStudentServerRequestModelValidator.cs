using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStudentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStudentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStudentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1f7ca01fbd5c0db03da8d9753ff0229d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/