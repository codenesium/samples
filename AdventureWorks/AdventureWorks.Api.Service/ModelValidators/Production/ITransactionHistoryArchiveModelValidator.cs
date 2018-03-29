using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ITransactionHistoryArchiveModelValidator
	{
		ValidationResult Validate(TransactionHistoryArchiveModel entity);

		Task<ValidationResult> ValidateAsync(TransactionHistoryArchiveModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>bf0dfdb6870e59516038297aebba8726</Hash>
</Codenesium>*/