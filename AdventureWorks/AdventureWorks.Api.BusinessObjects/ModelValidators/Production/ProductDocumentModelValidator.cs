using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductDocumentModelValidator: AbstractProductDocumentModelValidator, IProductDocumentModelValidator
	{
		public ProductDocumentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductDocumentModel model)
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductDocumentModel model)
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>1395c1ef920aa3ccaff61ef5c15c6a87</Hash>
</Codenesium>*/