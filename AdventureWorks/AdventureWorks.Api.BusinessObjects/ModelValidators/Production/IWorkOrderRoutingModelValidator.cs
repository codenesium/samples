using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiWorkOrderRoutingModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>eb55c3d34532072c58226ccad537245a</Hash>
</Codenesium>*/