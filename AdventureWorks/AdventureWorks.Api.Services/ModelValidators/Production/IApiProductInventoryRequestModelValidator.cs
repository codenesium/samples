using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductInventoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>301162548227ad5d40dc6654c7a3a1ca</Hash>
</Codenesium>*/