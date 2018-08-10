using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>71fc458bad14fb0b19e51dff6af70962</Hash>
</Codenesium>*/