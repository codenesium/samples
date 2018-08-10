using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiContactTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>440594d81ca17fbf0803827011422ed1</Hash>
</Codenesium>*/