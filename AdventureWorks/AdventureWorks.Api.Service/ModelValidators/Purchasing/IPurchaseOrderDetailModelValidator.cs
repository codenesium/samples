using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPurchaseOrderDetailModelValidator
	{
		ValidationResult Validate(PurchaseOrderDetailModel entity);

		Task<ValidationResult> ValidateAsync(PurchaseOrderDetailModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>d2c38342169332858bfb1722a47fb67f</Hash>
</Codenesium>*/