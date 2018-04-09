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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>241af7013f712a86b553b729cf121c32</Hash>
</Codenesium>*/