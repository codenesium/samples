using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiWorkOrderRoutingRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ec328b39d0496bbbb3089ee0ab68949a</Hash>
</Codenesium>*/