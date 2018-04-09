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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>82b4b9542174e455fa62c1b8fa3d7c70</Hash>
</Codenesium>*/