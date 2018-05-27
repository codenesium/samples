using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiLinkRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>49f08658829afaedad73eb47a1cf602b</Hash>
</Codenesium>*/