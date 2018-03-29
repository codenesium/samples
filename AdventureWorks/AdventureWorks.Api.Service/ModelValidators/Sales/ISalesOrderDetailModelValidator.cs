using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesOrderDetailModelValidator
	{
		ValidationResult Validate(SalesOrderDetailModel entity);

		Task<ValidationResult> ValidateAsync(SalesOrderDetailModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>95919e8a225dca10d3bc570ba912d35b</Hash>
</Codenesium>*/