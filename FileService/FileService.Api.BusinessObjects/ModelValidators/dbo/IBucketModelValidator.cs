using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBucketModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(BucketModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, BucketModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9880a127f2a6bc1097ac3122b58d2f02</Hash>
</Codenesium>*/