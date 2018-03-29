using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ITransactionHistoryModelValidator
	{
		ValidationResult Validate(TransactionHistoryModel entity);

		Task<ValidationResult> ValidateAsync(TransactionHistoryModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>d590a10a7a45c2a7ea96acb8a20f688a</Hash>
</Codenesium>*/