using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiTransactionHistoryArchiveModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>789d22157737885ef8ca58bdf9408be8</Hash>
</Codenesium>*/