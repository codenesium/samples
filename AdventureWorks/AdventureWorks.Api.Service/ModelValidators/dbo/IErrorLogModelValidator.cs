using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IErrorLogModelValidator
	{
		ValidationResult Validate(ErrorLogModel entity);

		Task<ValidationResult> ValidateAsync(ErrorLogModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>994c530eb48d5b5877cff860be4b6023</Hash>
</Codenesium>*/