using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesTerritoryHistoryModelValidator
	{
		ValidationResult Validate(SalesTerritoryHistoryModel entity);

		Task<ValidationResult> ValidateAsync(SalesTerritoryHistoryModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>3de5892dec72cd0df68e55da434b1d52</Hash>
</Codenesium>*/