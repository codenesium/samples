using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiCommentsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommentsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8bd72f3c67e469bcead4b20211c2830e</Hash>
</Codenesium>*/