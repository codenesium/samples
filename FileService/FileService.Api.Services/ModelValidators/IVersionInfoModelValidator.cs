using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.Services
{
	public interface IApiVersionInfoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(long id);
	}
}

/*<Codenesium>
    <Hash>581ed4301921406037775444ad7d5996</Hash>
</Codenesium>*/