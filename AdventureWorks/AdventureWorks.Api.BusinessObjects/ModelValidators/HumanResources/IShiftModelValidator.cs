using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IShiftModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ShiftModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ShiftModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24327e8532bbcde607202b36b9e11594</Hash>
</Codenesium>*/