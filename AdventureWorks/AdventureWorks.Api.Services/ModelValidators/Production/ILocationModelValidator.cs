using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiLocationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>106066ae65e317c096e9de0757b58f56</Hash>
</Codenesium>*/