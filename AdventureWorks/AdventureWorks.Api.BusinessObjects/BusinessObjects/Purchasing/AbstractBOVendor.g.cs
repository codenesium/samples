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
	public abstract class AbstractBOVendor
	{
		private IVendorRepository vendorRepository;
		private IVendorModelValidator vendorModelValidator;
		private ILogger logger;

		public AbstractBOVendor(
			ILogger logger,
			IVendorRepository vendorRepository,
			IVendorModelValidator vendorModelValidator)

		{
			this.vendorRepository = vendorRepository;
			this.vendorModelValidator = vendorModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			VendorModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.vendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.vendorRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			VendorModel model)
		{
			ActionResponse response = new ActionResponse(await this.vendorModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.vendorRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.vendorModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.vendorRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.vendorRepository.GetById(businessEntityID);
		}

		public virtual POCOVendor GetByIdDirect(int businessEntityID)
		{
			return this.vendorRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.vendorRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.vendorRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOVendor> GetWhereDirect(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.vendorRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>848064ddb25b4fa8cd272a28abebcb11</Hash>
</Codenesium>*/