using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractSaleService : AbstractService
	{
		protected ISaleRepository SaleRepository { get; private set; }

		protected IApiSaleRequestModelValidator SaleModelValidator { get; private set; }

		protected IBOLSaleMapper BolSaleMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		protected IBOLSaleTicketsMapper BolSaleTicketsMapper { get; private set; }

		protected IDALSaleTicketsMapper DalSaleTicketsMapper { get; private set; }

		private ILogger logger;

		public AbstractSaleService(
			ILogger logger,
			ISaleRepository saleRepository,
			IApiSaleRequestModelValidator saleModelValidator,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper,
			IBOLSaleTicketsMapper bolSaleTicketsMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base()
		{
			this.SaleRepository = saleRepository;
			this.SaleModelValidator = saleModelValidator;
			this.BolSaleMapper = bolSaleMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.BolSaleTicketsMapper = bolSaleTicketsMapper;
			this.DalSaleTicketsMapper = dalSaleTicketsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSaleResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SaleRepository.All(limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSaleResponseModel> Get(int id)
		{
			var record = await this.SaleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSaleResponseModel>> Create(
			ApiSaleRequestModel model)
		{
			CreateResponse<ApiSaleResponseModel> response = new CreateResponse<ApiSaleResponseModel>(await this.SaleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSaleMapper.MapModelToBO(default(int), model);
				var record = await this.SaleRepository.Create(this.DalSaleMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSaleResponseModel>> Update(
			int id,
			ApiSaleRequestModel model)
		{
			var validationResult = await this.SaleModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSaleMapper.MapModelToBO(id, model);
				await this.SaleRepository.Update(this.DalSaleMapper.MapBOToEF(bo));

				var record = await this.SaleRepository.Get(id);

				return new UpdateResponse<ApiSaleResponseModel>(this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSaleResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SaleModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SaleRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiSaleResponseModel>> ByTransactionId(int transactionId)
		{
			List<Sale> records = await this.SaleRepository.ByTransactionId(transactionId);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0)
		{
			List<SaleTickets> records = await this.SaleRepository.SaleTickets(saleId, limit, offset);

			return this.BolSaleTicketsMapper.MapBOToModel(this.DalSaleTicketsMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>fd38f0e9a2716f6fa7d0dea4368f4cdc</Hash>
</Codenesium>*/