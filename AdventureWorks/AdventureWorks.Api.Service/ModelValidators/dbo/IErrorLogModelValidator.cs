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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>b976862c9d206730045c076c2fd514b7</Hash>
</Codenesium>*/