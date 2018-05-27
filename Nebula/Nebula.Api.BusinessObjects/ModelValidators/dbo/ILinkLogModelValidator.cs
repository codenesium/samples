using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiLinkLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkLogRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3e46bd4a5755b04e867d022c0cc6754b</Hash>
</Codenesium>*/