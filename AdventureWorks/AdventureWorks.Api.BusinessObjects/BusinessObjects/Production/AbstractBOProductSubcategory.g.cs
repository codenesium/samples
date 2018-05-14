using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOProductSubcategory
	{
		private IProductSubcategoryRepository productSubcategoryRepository;
		private IApiProductSubcategoryModelValidator productSubcategoryModelValidator;
		private ILogger logger;

		public AbstractBOProductSubcategory(
			ILogger logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryModelValidator productSubcategoryModelValidator)

		{
			this.productSubcategoryRepository = productSubcategoryRepository;
			this.productSubcategoryModelValidator = productSubcategoryModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductSubcategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productSubcategoryRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductSubcategory Get(int productSubcategoryID)
		{
			return this.productSubcategoryRepository.Get(productSubcategoryID);
		}

		public virtual async Task<CreateResponse<POCOProductSubcategory>> Create(
			ApiProductSubcategoryModel model)
		{
			CreateResponse<POCOProductSubcategory> response = new CreateResponse<POCOProductSubcategory>(await this.productSubcategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductSubcategory record = this.productSubcategoryRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productSubcategoryID,
			ApiProductSubcategoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model));

			if (response.Success)
			{
				this.productSubcategoryRepository.Update(productSubcategoryID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

			if (response.Success)
			{
				this.productSubcategoryRepository.Delete(productSubcategoryID);
			}
			return response;
		}

		public POCOProductSubcategory GetName(string name)
		{
			return this.productSubcategoryRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>fbd1b1a485899c422d0cbea35f461ec8</Hash>
</Codenesium>*/