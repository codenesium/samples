using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IWorkOrderRoutingModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(WorkOrderRoutingModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, WorkOrderRoutingModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9b5963e24a72fd22b85aac6a656077b7</Hash>
</Codenesium>*/