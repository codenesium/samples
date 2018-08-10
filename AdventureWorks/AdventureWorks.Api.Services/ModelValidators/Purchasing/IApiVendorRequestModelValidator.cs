using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiVendorRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVendorRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c129ea61a5ee49a336e6c616f178f0a4</Hash>
</Codenesium>*/