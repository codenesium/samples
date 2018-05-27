using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiBucketRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBucketRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5db0806bbfb5f1f57189b3d04bae5cf7</Hash>
</Codenesium>*/