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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>b9b4967d6cabe09c8cb49837fa4b4437</Hash>
</Codenesium>*/