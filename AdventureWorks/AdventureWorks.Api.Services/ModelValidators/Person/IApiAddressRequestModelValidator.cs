using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>199635a2d66fac32a7c3ed4afc354050</Hash>
</Codenesium>*/