using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IDatabaseLogModelValidator
	{
		ValidationResult Validate(DatabaseLogModel entity);

		Task<ValidationResult> ValidateAsync(DatabaseLogModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>daf5c8e3cb162415cc706a4e06901193</Hash>
</Codenesium>*/