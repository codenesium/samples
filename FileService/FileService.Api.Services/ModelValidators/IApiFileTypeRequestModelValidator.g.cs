using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiFileTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7a6b79aef8542de7901b1cbe37e74b7d</Hash>
</Codenesium>*/