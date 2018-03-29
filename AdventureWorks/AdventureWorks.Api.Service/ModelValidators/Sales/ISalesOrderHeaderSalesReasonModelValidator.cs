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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>694f3dde99dc12a53273e927cc174a32</Hash>
</Codenesium>*/