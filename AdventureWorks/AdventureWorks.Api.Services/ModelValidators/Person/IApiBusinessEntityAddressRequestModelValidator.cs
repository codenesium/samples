using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiBusinessEntityAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1b8547d50107c157bd3487332b60f959</Hash>
</Codenesium>*/