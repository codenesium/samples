using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiBucketRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBucketRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7a52e7d977ad896bf094be5c9a023f92</Hash>
</Codenesium>*/