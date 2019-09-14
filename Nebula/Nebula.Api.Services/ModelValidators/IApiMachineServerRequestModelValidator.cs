using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiMachineServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMachineServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ed999a520e61f0a86bd2f0245c324c08</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/