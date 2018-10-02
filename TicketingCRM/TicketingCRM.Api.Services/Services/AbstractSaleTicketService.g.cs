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
	public abstract class AbstractSaleTicketService : AbstractService
	{
		protected ISaleTicketRepository SaleTicketRepository { get; private set; }

		protected IApiSaleTicketRequestModelValidator SaleTicketModelValidator { get; private set; }

		protected IBOLSaleTicketMapper BolSaleTicketMapper { get; private set; }

		protected IDALSaleTicketMapper DalSaleTicketMapper { get; private set; }

		private ILogger logger;

		public AbstractSaleTicketService(
			ILogger logger,
			ISaleTicketRepository saleTicketRepository,
			IApiSaleTicketRequestModelValidator saleTicketModelValidator,
			IBOLSaleTicketMapper bolSaleTicketMapper,
			IDALSaleTicketMapper dalSaleTicketMapper)
			: base()
		{
			this.SaleTicketRepository = saleTicketRepository;
			this.SaleTicketModelValidator = saleTicketModelValidator;
			this.BolSaleTicketMapper = bolSaleTicketMapper;
			this.DalSaleTicketMapper = dalSaleTicketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSaleTicketResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SaleTicketRepository.All(limit, offset);

			return this.BolSaleTicketMapper.MapBOToModel(this.DalSaleTicketMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSaleTicketResponseModel> Get(int id)
		{
			var record = await this.SaleTicketRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSaleTicketMapper.MapBOToModel(this.DalSaleTicketMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSaleTicketResponseModel>> Create(
			ApiSaleTicketRequestModel model)
		{
			CreateResponse<ApiSaleTicketResponseModel> response = new CreateResponse<ApiSaleTicketResponseModel>(await this.SaleTicketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSaleTicketMapper.MapModelToBO(default(int), model);
				var record = await this.SaleTicketRepository.Create(this.DalSaleTicketMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSaleTicketMapper.MapBOToModel(this.DalSaleTicketMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSaleTicketResponseModel>> Update(
			int id,
			ApiSaleTicketRequestModel model)
		{
			var validationResult = await this.SaleTicketModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSaleTicketMapper.MapModelToBO(id, model);
				await this.SaleTicketRepository.Update(this.DalSaleTicketMapper.MapBOToEF(bo));

				var record = await this.SaleTicketRepository.Get(id);

				return new UpdateResponse<ApiSaleTicketResponseModel>(this.BolSaleTicketMapper.MapBOToModel(this.DalSaleTicketMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSaleTicketResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SaleTicketModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SaleTicketRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiSaleTicketResponseModel>> ByTicketId(int ticketId, int limit = 0, int offset = int.MaxValue)
		{
			List<SaleTicket> records = await this.SaleTicketRepository.ByTicketId(ticketId, limit, offset);

			return this.BolSaleTicketMapper.MapBOToModel(this.DalSaleTicketMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1312a31076f6f48ac8854f890668a720</Hash>
</Codenesium>*/