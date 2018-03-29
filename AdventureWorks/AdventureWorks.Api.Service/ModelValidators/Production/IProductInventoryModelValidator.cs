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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>47d2d6d004e4011409a7ffdce96c734e</Hash>
</Codenesium>*/