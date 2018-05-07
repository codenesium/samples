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

		public virtual POCOVendor Get(int businessEntityID)
		{
			return this.vendorRepository.Get(businessEntityID);
		}

		public virtual List<POCOVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.vendorRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>2d60177052e8d4921e000d53292231f7</Hash>
</Codenesium>*/