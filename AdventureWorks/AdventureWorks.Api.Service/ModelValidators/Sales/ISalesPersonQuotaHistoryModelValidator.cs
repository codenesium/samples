using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesPersonQuotaHistoryModelValidator
	{
		ValidationResult Validate(SalesPersonQuotaHistoryModel entity);

		Task<ValidationResult> ValidateAsync(SalesPersonQuotaHistoryModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>07257058fcee8e3cc07eebc68507fbc2</Hash>
</Codenesium>*/