using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public interface IApiBucketRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBucketRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0199523c393da29984a4ac669fa26c2f</Hash>
</Codenesium>*/