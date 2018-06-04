using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiCultureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCultureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>660086234fdba7ed1d21eb00e8f3a42b</Hash>
</Codenesium>*/