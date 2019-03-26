using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>821618ef7daa9372d8e78bf19d7b0f43</Hash>
</Codenesium>*/