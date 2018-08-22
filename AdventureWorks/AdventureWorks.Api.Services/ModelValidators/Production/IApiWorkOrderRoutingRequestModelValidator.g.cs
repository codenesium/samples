using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiWorkOrderRoutingRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>36a6a4d88f379d595f1de604ba67d3f4</Hash>
</Codenesium>*/