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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>e5008a0ba7f24d04e42bf1c6e5816cba</Hash>
</Codenesium>*/