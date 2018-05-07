using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IErrorLogModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ErrorLogModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ErrorLogModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3c6d9f68fb857703c46b7361039974dd</Hash>
</Codenesium>*/