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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>7970d89ee976c61fff55f7b883c51777</Hash>
</Codenesium>*/