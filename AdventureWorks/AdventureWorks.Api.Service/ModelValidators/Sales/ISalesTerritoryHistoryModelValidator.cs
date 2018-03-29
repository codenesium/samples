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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>f26ae6abf3126e42d584fe19543347ab</Hash>
</Codenesium>*/