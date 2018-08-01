using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiLocationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>923cf73a8afe78c2c498d00dde05b7d6</Hash>
</Codenesium>*/