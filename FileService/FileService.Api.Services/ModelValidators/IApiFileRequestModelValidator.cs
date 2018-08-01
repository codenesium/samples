using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>653bf50594941a5e502078f64b469d6a</Hash>
</Codenesium>*/