using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiPasswordRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPasswordRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5d20c4b08b52125734d116da008b8feb</Hash>
</Codenesium>*/