using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IWorkOrderModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(WorkOrderModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, WorkOrderModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>65360579f540182a28e0294c2a3e5a1a</Hash>
</Codenesium>*/