using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiVersionInfoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>7d405a03d8a3f9db57d056c9a140d663</Hash>
</Codenesium>*/