using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBusinessEntityAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7a384a30c389c72bcdd73652266e4432</Hash>
</Codenesium>*/