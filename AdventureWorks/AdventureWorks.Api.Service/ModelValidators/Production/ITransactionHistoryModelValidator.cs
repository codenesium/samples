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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>811cad4906cdcd08f82889be9606682e</Hash>
</Codenesium>*/