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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>0ea8850408a39562b25bb97b9449c42f</Hash>
</Codenesium>*/