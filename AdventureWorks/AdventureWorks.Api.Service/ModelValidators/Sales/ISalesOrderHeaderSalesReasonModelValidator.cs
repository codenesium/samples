using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesOrderHeaderSalesReasonModelValidator
	{
		ValidationResult Validate(SalesOrderHeaderSalesReasonModel entity);

		Task<ValidationResult> ValidateAsync(SalesOrderHeaderSalesReasonModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>205b3c5ece72a9cefd2dab6485e480e9</Hash>
</Codenesium>*/