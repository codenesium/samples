using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiLikeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLikeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLikeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>214f928a2ce906cead9d87490ef2ebc2</Hash>
</Codenesium>*/