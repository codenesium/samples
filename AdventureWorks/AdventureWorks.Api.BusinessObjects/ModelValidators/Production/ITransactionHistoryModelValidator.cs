using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ITransactionHistoryModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(TransactionHistoryModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, TransactionHistoryModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ed0310408e60caee21acbfe0b5d0ca91</Hash>
</Codenesium>*/