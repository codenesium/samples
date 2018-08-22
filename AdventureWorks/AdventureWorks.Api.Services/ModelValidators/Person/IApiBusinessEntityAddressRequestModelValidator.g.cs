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
    <Hash>b9653ba44624e116196fb7d1f00cbc9b</Hash>
</Codenesium>*/