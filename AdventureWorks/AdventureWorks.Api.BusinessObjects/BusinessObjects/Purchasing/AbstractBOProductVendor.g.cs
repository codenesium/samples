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
	public abstract class AbstractBOProductVendor: AbstractBOManager
	{
		private IProductVendorRepository productVendorRepository;
		private IApiProductVendorModelValidator productVendorModelValidator;
		private ILogger logger;

		public AbstractBOProductVendor(
			ILogger logger,
			IProductVendorRepository productVendorRepository,
			IApiProductVendorModelValidator productVendorModelValidator)
			: base()

		{
			this.productVendorRepository = productVendorRepository;
			this.productVendorModelValidator = productVendorModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productVendorRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductVendor> Get(int productID)
		{
			return this.productVendorRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProductVendor>> Create(
			ApiProductVendorModel model)
		{
			CreateResponse<POCOProductVendor> response = new CreateResponse<POCOProductVendor>(await this.productVendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductVendor record = await this.productVendorRepository.Create(model);

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
				await this.productVendorRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productVendorModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productVendorRepository.Delete(productID);
			}
			return response;
		}

		public async Task<List<POCOProductVendor>> GetBusinessEntityID(int businessEntityID)
		{
			return await this.productVendorRepository.GetBusinessEntityID(businessEntityID);
		}
		public async Task<List<POCOProductVendor>> GetUnitMeasureCode(string unitMeasureCode)
		{
			return await this.productVendorRepository.GetUnitMeasureCode(unitMeasureCode);
		}
	}
}

/*<Codenesium>
    <Hash>35577072af0b285d5a953b17168f4df2</Hash>
</Codenesium>*/