using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IBillOfMaterialsModelValidator
	{
		ValidationResult Validate(BillOfMaterialsModel entity);

		Task<ValidationResult> ValidateAsync(BillOfMaterialsModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>7c04d39f3c4ee730df291816b3aa4568</Hash>
</Codenesium>*/