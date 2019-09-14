using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1c3f539535c4669e0ef0906e1ed8f106</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/