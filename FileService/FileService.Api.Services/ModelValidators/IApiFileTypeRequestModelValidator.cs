using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>1c2284cb5d8e7735fae697cf935f429f</Hash>
</Codenesium>*/