using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTestAllFieldTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTestAllFieldTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTestAllFieldTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>eb085bddaa9c7966030f2a7df527cdeb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/