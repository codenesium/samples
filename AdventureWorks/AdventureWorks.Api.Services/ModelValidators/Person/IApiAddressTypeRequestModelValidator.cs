using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiAddressTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9a11926215981c9dad1930cdaab69bb0</Hash>
</Codenesium>*/