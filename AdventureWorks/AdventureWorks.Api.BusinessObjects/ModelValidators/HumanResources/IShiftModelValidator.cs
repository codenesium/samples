using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IShiftModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ShiftModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ShiftModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>82fa7c498f27d74426b06cbb0005107a</Hash>
</Codenesium>*/