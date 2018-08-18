using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cc33d2408352bbc7d243ff098b83d0c0</Hash>
</Codenesium>*/