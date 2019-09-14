using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiChainStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fb9665116690fa87b61d00d1172f86a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/