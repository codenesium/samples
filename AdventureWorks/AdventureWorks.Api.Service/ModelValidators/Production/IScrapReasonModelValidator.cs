using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IScrapReasonModelValidator
	{
		ValidationResult Validate(ScrapReasonModel entity);

		Task<ValidationResult> ValidateAsync(ScrapReasonModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>6cc4620df52774534830c7af8208d50e</Hash>
</Codenesium>*/