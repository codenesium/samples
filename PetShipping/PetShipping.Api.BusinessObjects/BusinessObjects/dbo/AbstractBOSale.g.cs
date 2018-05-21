using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOSale: AbstractBOManager
	{
		private ISaleRepository saleRepository;
		private IApiSaleModelValidator saleModelValidator;
		private ILogger logger;

		public AbstractBOSale(
			ILogger logger,
			ISaleRepository saleRepository,
			IApiSaleModelValidator saleModelValidator)
			: base()

		{
			this.saleRepository = saleRepository;
			this.saleModelValidator = saleModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSale>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.saleRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSale> Get(int id)
		{
			return this.saleRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOSale>> Create(
			ApiSaleModel model)
		{
			CreateResponse<POCOSale> response = new CreateResponse<POCOSale>(await this.saleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSale record = await this.saleRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSaleModel model)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.saleRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.saleRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>66cd09e3fcfb53689f7c77c92c6dba8c</Hash>
</Codenesium>*/