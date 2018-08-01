using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>9fc3cf98d321c1f0541d5df89e4e96b6</Hash>
</Codenesium>*/