using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IWorkOrderModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(WorkOrderModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, WorkOrderModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>78b7596b89e4dc055c0103393acd04cd</Hash>
</Codenesium>*/