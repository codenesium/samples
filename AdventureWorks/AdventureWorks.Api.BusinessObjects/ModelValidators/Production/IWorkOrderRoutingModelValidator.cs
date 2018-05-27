using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiWorkOrderRoutingRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>58ce268c37166db99cca6eb1dbd1ab41</Hash>
</Codenesium>*/