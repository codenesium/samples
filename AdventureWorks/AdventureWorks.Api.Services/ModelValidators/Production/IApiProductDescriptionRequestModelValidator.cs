using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductDescriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3b71218fd0ae106bc8c0cfd1851c4da4</Hash>
</Codenesium>*/