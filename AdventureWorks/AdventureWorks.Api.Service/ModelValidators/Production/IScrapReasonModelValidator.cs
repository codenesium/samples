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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>97a6af579da63133423f8b12f50c2da7</Hash>
</Codenesium>*/