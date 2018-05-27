using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCultureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCultureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>52b6e93e371bd5f345db567168e828d6</Hash>
</Codenesium>*/