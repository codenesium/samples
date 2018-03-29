using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IBusinessEntityModelValidator
	{
		ValidationResult Validate(BusinessEntityModel entity);

		Task<ValidationResult> ValidateAsync(BusinessEntityModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>fd67e0941c66d7a5dcf97469550f7d54</Hash>
</Codenesium>*/