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
	public abstract class AbstractBOProductVendor
	{
		private IProductVendorRepository productVendorRepository;
		private IProductVendorModelValidator productVendorModelValidator;
		private ILogger logger;

		public AbstractBOProductVendor(
			ILogger logger,
			IProductVendorRepository productVendorRepository,
			IProductVendorModelValidator productVendorModelValidator)

		{
			this.productVendorRepository = productVendorRepository;
			this.productVendorModelValidator = productVendorModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductVendorModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productVendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productVendorRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ProductVendorModel model)
		{
			ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				this.productVendorRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				this.productVendorRepository.Delete(productID);
			}
			return response;
		}

		public virtual POCOProductVendor Get(int productID)
		{
			return this.productVendorRepository.Get(productID);
		}

		public virtual List<POCOProductVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productVendorRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>66b2e27a7b5495ca00894a298ec478f5</Hash>
</Codenesium>*/