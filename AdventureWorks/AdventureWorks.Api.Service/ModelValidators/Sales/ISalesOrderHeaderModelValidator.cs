using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesOrderHeaderModelValidator
	{
		ValidationResult Validate(SalesOrderHeaderModel entity);

		Task<ValidationResult> ValidateAsync(SalesOrderHeaderModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>5492f5352c939c0f4c8f57d4e3fbb4d0</Hash>
</Codenesium>*/