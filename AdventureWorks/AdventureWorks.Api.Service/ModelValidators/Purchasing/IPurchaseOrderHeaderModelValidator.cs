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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>639aee62eb40b71e9dc68605b5d75af0</Hash>
</Codenesium>*/