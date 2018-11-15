using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductSubcategoryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dae6d21bbf962a7efdabe562f464e3d1</Hash>
</Codenesium>*/