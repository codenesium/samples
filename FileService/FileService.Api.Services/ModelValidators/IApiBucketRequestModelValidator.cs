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
    <Hash>634bbab3970692df89ab7476882121f9</Hash>
</Codenesium>*/