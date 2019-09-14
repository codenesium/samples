using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiChainServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>30f924bda83494a1b734196a499d6da2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/