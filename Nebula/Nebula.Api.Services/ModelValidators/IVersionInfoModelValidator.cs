using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiVersionInfoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>bf63ff527a73da3ef4677fad4e341989</Hash>
</Codenesium>*/