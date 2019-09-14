using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ba71aa376bf1215059a2a7c056fba85f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/