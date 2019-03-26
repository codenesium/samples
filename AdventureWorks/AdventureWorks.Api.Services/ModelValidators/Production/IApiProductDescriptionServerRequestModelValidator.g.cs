using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductDescriptionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4462a65bc68ee9126c1235ceced2b6e5</Hash>
</Codenesium>*/