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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>f139177ee58fb9ea9ead2817ada2de7e</Hash>
</Codenesium>*/