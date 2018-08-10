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
	public abstract class AbstractSaleTicketsService : AbstractService
	{
		protected ISaleTicketsRepository SaleTicketsRepository { get; private set; }

		protected IApiSaleTicketsRequestModelValidator SaleTicketsModelValidator { get; private set; }

		protected IBOLSaleTicketsMapper BolSaleTicketsMapper { get; private set; }

		protected IDALSaleTicketsMapper DalSaleTicketsMapper { get; private set; }

		private ILogger logger;

		public AbstractSaleTicketsService(
			ILogger logger,
			ISaleTicketsRepository saleTicketsRepository,
			IApiSaleTicketsRequestModelValidator saleTicketsModelValidator,
			IBOLSaleTicketsMapper bolSaleTicketsMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base()
		{
			this.SaleTicketsRepository = saleTicketsRepository;
			this.SaleTicketsModelValidator = saleTicketsModelValidator;
			this.BolSaleTicketsMapper = bolSaleTicketsMapper;
			this.DalSaleTicketsMapper = dalSaleTicketsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSaleTicketsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SaleTicketsRepository.All(limit, offset);

			return this.BolSaleTicketsMapper.MapBOToModel(this.DalSaleTicketsMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSaleTicketsResponseModel> Get(int id)
		{
			var record = await this.SaleTicketsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSaleTicketsMapper.MapBOToModel(this.DalSaleTicketsMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSaleTicketsResponseModel>> Create(
			ApiSaleTicketsRequestModel model)
		{
			CreateResponse<ApiSaleTicketsResponseModel> response = new CreateResponse<ApiSaleTicketsResponseModel>(await this.SaleTicketsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSaleTicketsMapper.MapModelToBO(default(int), model);
				var record = await this.SaleTicketsRepository.Create(this.DalSaleTicketsMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSaleTicketsMapper.MapBOToModel(this.DalSaleTicketsMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSaleTicketsResponseModel>> Update(
			int id,
			ApiSaleTicketsRequestModel model)
		{
			var validationResult = await this.SaleTicketsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSaleTicketsMapper.MapModelToBO(id, model);
				await this.SaleTicketsRepository.Update(this.DalSaleTicketsMapper.MapBOToEF(bo));

				var record = await this.SaleTicketsRepository.Get(id);

				return new UpdateResponse<ApiSaleTicketsResponseModel>(this.BolSaleTicketsMapper.MapBOToModel(this.DalSaleTicketsMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSaleTicketsResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SaleTicketsModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SaleTicketsRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiSaleTicketsResponseModel>> ByTicketId(int ticketId)
		{
			List<SaleTickets> records = await this.SaleTicketsRepository.ByTicketId(ticketId);

			return this.BolSaleTicketsMapper.MapBOToModel(this.DalSaleTicketsMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>832978acc1b02db387a02b41e25e6c76</Hash>
</Codenesium>*/