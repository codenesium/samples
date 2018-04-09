using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesTerritoryModelValidator
	{
		ValidationResult Validate(SalesTerritoryModel entity);

		Task<ValidationResult> ValidateAsync(SalesTerritoryModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>ba62be3238a9d5e713ef9ba7ed3ac3a9</Hash>
</Codenesium>*/