using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiLinkTypesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkTypesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>25c69ff34876b9146dded9c7da1883b8</Hash>
</Codenesium>*/