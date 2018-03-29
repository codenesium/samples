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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>f6e7b280918baa1e14f1117c9ee4ef35</Hash>
</Codenesium>*/