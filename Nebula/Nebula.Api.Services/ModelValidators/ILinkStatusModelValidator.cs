using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiLinkStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>de63b0584ab865a0ee5a894527e06f38</Hash>
</Codenesium>*/