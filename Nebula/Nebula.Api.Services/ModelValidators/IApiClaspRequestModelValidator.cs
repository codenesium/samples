using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiClaspRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1d7bdcd7f6ede7f70754c07745e40303</Hash>
</Codenesium>*/