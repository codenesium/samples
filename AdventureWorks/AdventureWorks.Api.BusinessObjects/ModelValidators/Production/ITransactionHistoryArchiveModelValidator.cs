using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ITransactionHistoryArchiveModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(TransactionHistoryArchiveModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, TransactionHistoryArchiveModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e655b74aa3d513e229525eab38ea0da9</Hash>
</Codenesium>*/