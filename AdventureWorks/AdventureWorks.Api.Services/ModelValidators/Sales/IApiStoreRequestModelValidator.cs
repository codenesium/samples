using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiStoreRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStoreRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ebc0b2495dabd05257d1584cb89de7b4</Hash>
</Codenesium>*/