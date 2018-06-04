using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.Services
{
	public interface IApiFileRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5cd5c112794e25d01684e653e8edeb26</Hash>
</Codenesium>*/