using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPersonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b24c461f01f23273e47be1223f62bd43</Hash>
</Codenesium>*/