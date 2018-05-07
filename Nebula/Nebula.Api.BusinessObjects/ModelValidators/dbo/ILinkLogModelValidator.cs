using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkLogModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LinkLogModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, LinkLogModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>38fcd219552a67f015c28a8a86bbc353</Hash>
</Codenesium>*/