using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IErrorLogModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ErrorLogModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ErrorLogModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6818bce7080e4ff9e6242a66b50d8b24</Hash>
</Codenesium>*/