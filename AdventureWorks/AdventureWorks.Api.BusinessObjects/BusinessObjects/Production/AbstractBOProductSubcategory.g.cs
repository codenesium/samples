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
	public abstract class AbstractBOProductSubcategory: AbstractBOManager
	{
		private IProductSubcategoryRepository productSubcategoryRepository;
		private IApiProductSubcategoryModelValidator productSubcategoryModelValidator;
		private ILogger logger;

		public AbstractBOProductSubcategory(
			ILogger logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryModelValidator productSubcategoryModelValidator)
			: base()

		{
			this.productSubcategoryRepository = productSubcategoryRepository;
			this.productSubcategoryModelValidator = productSubcategoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productSubcategoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductSubcategory> Get(int productSubcategoryID)
		{
			return this.productSubcategoryRepository.Get(productSubcategoryID);
		}

		public virtual async Task<CreateResponse<POCOProductSubcategory>> Create(
			ApiProductSubcategoryModel model)
		{
			CreateResponse<POCOProductSubcategory> response = new CreateResponse<POCOProductSubcategory>(await this.productSubcategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductSubcategory record = await this.productSubcategoryRepository.Create(model);

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
				await this.productSubcategoryRepository.Update(productSubcategoryID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

			if (response.Success)
			{
				await this.productSubcategoryRepository.Delete(productSubcategoryID);
			}
			return response;
		}

		public async Task<POCOProductSubcategory> GetName(string name)
		{
			return await this.productSubcategoryRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>d59518d824c1c92f4b58a2e75d2315ee</Hash>
</Codenesium>*/