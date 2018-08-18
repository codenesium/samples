using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBusinessEntityRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e547915ffdf4f99084731e7644d0678b</Hash>
</Codenesium>*/