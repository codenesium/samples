using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IUnitMeasureModelValidator
	{
		ValidationResult Validate(UnitMeasureModel entity);

		Task<ValidationResult> ValidateAsync(UnitMeasureModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>5732b99f735ee71b7ec74bee65b1faa2</Hash>
</Codenesium>*/