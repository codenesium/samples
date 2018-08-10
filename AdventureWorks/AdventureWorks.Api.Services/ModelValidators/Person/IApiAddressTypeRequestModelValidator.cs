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
    <Hash>4ca68b228fc1bbac830f190ac313685c</Hash>
</Codenesium>*/