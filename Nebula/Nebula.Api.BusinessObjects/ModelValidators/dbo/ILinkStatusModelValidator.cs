using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiLinkStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f46fa2e9e1b7cf090bc7e346d34a8023</Hash>
</Codenesium>*/