using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesPersonModelValidator
	{
		ValidationResult Validate(SalesPersonModel entity);

		Task<ValidationResult> ValidateAsync(SalesPersonModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>d3366b4cfa0122f31a9b1f935338e1b0</Hash>
</Codenesium>*/