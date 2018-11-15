using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiSchemaBPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSchemaBPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaBPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6d611a6f2c0b567cb20c0a44a24f1874</Hash>
</Codenesium>*/