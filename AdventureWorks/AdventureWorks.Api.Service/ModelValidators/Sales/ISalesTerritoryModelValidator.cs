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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>c35d86fbfb3f4badcbb76d574d8b248e</Hash>
</Codenesium>*/