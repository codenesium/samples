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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>15a27873096cf6fb176b8beeac6e857f</Hash>
</Codenesium>*/