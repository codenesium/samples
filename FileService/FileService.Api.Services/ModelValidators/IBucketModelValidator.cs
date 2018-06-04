using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
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
    <Hash>bc61404ffd1505de928373ce7ff3692f</Hash>
</Codenesium>*/