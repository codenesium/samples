using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAddressTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>21b4bc0ddf922307f519284ad6fbd565</Hash>
</Codenesium>*/