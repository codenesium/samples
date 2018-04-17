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

		public virtual ApiResponse GetById(int productID)
		{
			return this.productVendorRepository.GetById(productID);
		}

		public virtual POCOProductVendor GetByIdDirect(int productID)
		{
			return this.productVendorRepository.GetByIdDirect(productID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productVendorRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productVendorRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductVendor> GetWhereDirect(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productVendorRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>9fd16ca9215ff941018ec6c7120b2e4f</Hash>
</Codenesium>*/