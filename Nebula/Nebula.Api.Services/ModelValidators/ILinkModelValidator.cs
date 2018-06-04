using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiLinkRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>78966a08c32d52d0e134e158e220d61f</Hash>
</Codenesium>*/