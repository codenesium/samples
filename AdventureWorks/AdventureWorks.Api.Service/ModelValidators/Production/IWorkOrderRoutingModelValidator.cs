using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IWorkOrderRoutingModelValidator
	{
		ValidationResult Validate(WorkOrderRoutingModel entity);

		Task<ValidationResult> ValidateAsync(WorkOrderRoutingModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>041fcf9ee7788d007d64ea4f9f7ab3dc</Hash>
</Codenesium>*/