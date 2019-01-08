using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiVPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4b07398c0770b2b454153b585324fb95</Hash>
</Codenesium>*/