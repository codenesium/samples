using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOSale
	{
		private ISaleRepository saleRepository;
		private ISaleModelValidator saleModelValidator;
		private ILogger logger;

		public AbstractBOSale(
			ILogger logger,
			ISaleRepository saleRepository,
			ISaleModelValidator saleModelValidator)

		{
			this.saleRepository = saleRepository;
			this.saleModelValidator = saleModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSale> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.saleRepository.All(skip, take, orderClause);
		}

		public virtual POCOSale Get(int id)
		{
			return this.saleRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOSale>> Create(
			SaleModel model)
		{
			CreateResponse<POCOSale> response = new CreateResponse<POCOSale>(await this.saleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSale record = this.saleRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			SaleModel model)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.saleRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.saleRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7b6f0eef2902bf7960e64f1cc8ac2f4d</Hash>
</Codenesium>*/