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
    <Hash>3b000f1d16ae26282a276dd0ea4560d0</Hash>
</Codenesium>*/