using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.Services
{
	public interface IApiFileTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8fa944447046e97c61ca3b4d7e2b3965</Hash>
</Codenesium>*/