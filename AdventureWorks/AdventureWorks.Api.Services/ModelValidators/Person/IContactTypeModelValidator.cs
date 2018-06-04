using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiContactTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8a17c5ff616621841e4ecbe72b3b017f</Hash>
</Codenesium>*/