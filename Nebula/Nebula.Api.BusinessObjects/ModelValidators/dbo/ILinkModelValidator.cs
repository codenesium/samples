using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LinkModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LinkModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cf70bb2336f0fb2b156556dcf8649c40</Hash>
</Codenesium>*/