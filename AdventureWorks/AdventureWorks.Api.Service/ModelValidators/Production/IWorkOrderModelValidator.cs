using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IWorkOrderModelValidator
	{
		ValidationResult Validate(WorkOrderModel entity);

		Task<ValidationResult> ValidateAsync(WorkOrderModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>c23e22001ac72939cefb461082b96035</Hash>
</Codenesium>*/