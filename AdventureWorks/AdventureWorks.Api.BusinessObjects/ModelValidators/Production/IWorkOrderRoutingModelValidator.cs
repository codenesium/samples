using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IWorkOrderRoutingModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(WorkOrderRoutingModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, WorkOrderRoutingModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>193c1d4d1b4ddb2ce66e639b16ef4590</Hash>
</Codenesium>*/