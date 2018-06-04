using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiChainRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>94c45579a4442401ba864d4066ca9f42</Hash>
</Codenesium>*/