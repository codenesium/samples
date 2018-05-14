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
		private IApiVendorModelValidator vendorModelValidator;
		private ILogger logger;

		public AbstractBOVendor(
			ILogger logger,
			IVendorRepository vendorRepository,
			IApiVendorModelValidator vendorModelValidator)

		{
			this.vendorRepository = vendorRepository;
			this.vendorModelValidator = vendorModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.vendorRepository.All(skip, take, orderClause);
		}

		public virtual POCOVendor Get(int businessEntityID)
		{
			return this.vendorRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOVendor>> Create(
			ApiVendorModel model)
		{
			CreateResponse<POCOVendor> response = new CreateResponse<POCOVendor>(await this.vendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOVendor record = this.vendorRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiVendorModel model)
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

		public POCOVendor GetAccountNumber(string accountNumber)
		{
			return this.vendorRepository.GetAccountNumber(accountNumber);
		}
	}
}

/*<Codenesium>
    <Hash>a972518d095cc55098e8d12d0832c2a3</Hash>
</Codenesium>*/