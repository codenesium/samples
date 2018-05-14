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
		private IApiProductVendorModelValidator productVendorModelValidator;
		private ILogger logger;

		public AbstractBOProductVendor(
			ILogger logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorModelValidator productVendorModelValidator)

		{
			this.productVendorRepository = productVendorRepository;
			this.productVendorModelValidator = productVendorModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productVendorRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductVendor Get(int productID)
		{
			return this.productVendorRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProductVendor>> Create(
			ApiProductVendorModel model)
		{
			CreateResponse<POCOProductVendor> response = new CreateResponse<POCOProductVendor>(await this.productVendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductVendor record = this.productVendorRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductVendorModel model)
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

		public List<POCOProductVendor> GetBusinessEntityID(int businessEntityID)
		{
			return this.productVendorRepository.GetBusinessEntityID(businessEntityID);
		}
		public List<POCOProductVendor> GetUnitMeasureCode(string unitMeasureCode)
		{
			return this.productVendorRepository.GetUnitMeasureCode(unitMeasureCode);
		}
	}
}

/*<Codenesium>
    <Hash>07c01403e839ef141d146821a9c5d8a9</Hash>
</Codenesium>*/