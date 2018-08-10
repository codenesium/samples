using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBusinessEntityContactRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>30d35bad91cff7412b484babcac31a91</Hash>
</Codenesium>*/