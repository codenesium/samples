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
    <Hash>5fc44bddc738856f7414688738a2d5b1</Hash>
</Codenesium>*/