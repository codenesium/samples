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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>acf79dc6c7f52d74f0d5a0ba6a92d730</Hash>
</Codenesium>*/