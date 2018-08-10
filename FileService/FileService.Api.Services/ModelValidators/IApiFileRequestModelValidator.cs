using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiFileRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dc83d85e4ccb697cacf0e7d3b6d5f31a</Hash>
</Codenesium>*/