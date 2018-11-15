using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiContactTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiContactTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a82c5d0aa802b1aa668e24668269e324</Hash>
</Codenesium>*/