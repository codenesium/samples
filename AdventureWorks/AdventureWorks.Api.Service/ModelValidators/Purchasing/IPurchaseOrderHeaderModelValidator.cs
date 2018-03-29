using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPurchaseOrderHeaderModelValidator
	{
		ValidationResult Validate(PurchaseOrderHeaderModel entity);

		Task<ValidationResult> ValidateAsync(PurchaseOrderHeaderModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>5ab9451f1a82ced9f5d67bc28c7ff55f</Hash>
</Codenesium>*/