using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductModelProductDescriptionCultureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3bcbefed220ac39642b01c54103c0477</Hash>
</Codenesium>*/