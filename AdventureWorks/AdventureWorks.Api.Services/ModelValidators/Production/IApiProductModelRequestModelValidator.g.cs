using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductModelRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>be5d8228d3f47c6336b051cd9ee9f563</Hash>
</Codenesium>*/