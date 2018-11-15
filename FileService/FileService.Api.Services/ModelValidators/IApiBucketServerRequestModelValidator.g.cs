using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiBucketServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBucketServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e9512d7b47b4c09e809665f3a7a1b81f</Hash>
</Codenesium>*/