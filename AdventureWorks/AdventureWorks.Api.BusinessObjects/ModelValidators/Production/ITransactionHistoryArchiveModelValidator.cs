using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ITransactionHistoryArchiveModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(TransactionHistoryArchiveModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, TransactionHistoryArchiveModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd121497d0df41cad9ca41959e3c349a</Hash>
</Codenesium>*/