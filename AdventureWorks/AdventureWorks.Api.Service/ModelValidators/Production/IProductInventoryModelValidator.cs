using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductInventoryModelValidator
	{
		ValidationResult Validate(ProductInventoryModel entity);

		Task<ValidationResult> ValidateAsync(ProductInventoryModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>63d3e1278253a17dd33cd18e7efda487</Hash>
</Codenesium>*/