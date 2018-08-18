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
	public abstract class AbstractTicketService : AbstractService
	{
		protected ITicketRepository TicketRepository { get; private set; }

		protected IApiTicketRequestModelValidator TicketModelValidator { get; private set; }

		protected IBOLTicketMapper BolTicketMapper { get; private set; }

		protected IDALTicketMapper DalTicketMapper { get; private set; }

		protected IBOLSaleTicketsMapper BolSaleTicketsMapper { get; private set; }

		protected IDALSaleTicketsMapper DalSaleTicketsMapper { get; private set; }

		private ILogger logger;

		public AbstractTicketService(
			ILogger logger,
			ITicketRepository ticketRepository,
			IApiTicketRequestModelValidator ticketModelValidator,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper,
			IBOLSaleTicketsMapper bolSaleTicketsMapper,
			IDALSaleTicketsMapper dalSaleTicketsMapper)
			: base()
		{
			this.TicketRepository = ticketRepository;
			this.TicketModelValidator = ticketModelValidator;
			this.BolTicketMapper = bolTicketMapper;
			this.DalTicketMapper = dalTicketMapper;
			this.BolSaleTicketsMapper = bolSaleTicketsMapper;
			this.DalSaleTicketsMapper = dalSaleTicketsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTicketResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TicketRepository.All(limit, offset);

			return this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTicketResponseModel> Get(int id)
		{
			var record = await this.TicketRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTicketResponseModel>> Create(
			ApiTicketRequestModel model)
		{
			CreateResponse<ApiTicketResponseModel> response = new CreateResponse<ApiTicketResponseModel>(await this.TicketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTicketMapper.MapModelToBO(default(int), model);
				var record = await this.TicketRepository.Create(this.DalTicketMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketResponseModel>> Update(
			int id,
			ApiTicketRequestModel model)
		{
			var validationResult = await this.TicketModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTicketMapper.MapModelToBO(id, model);
				await this.TicketRepository.Update(this.DalTicketMapper.MapBOToEF(bo));

				var record = await this.TicketRepository.Get(id);

				return new UpdateResponse<ApiTicketResponseModel>(this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTicketResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TicketModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TicketRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiTicketResponseModel>> ByTicketStatusId(int ticketStatusId, int limit = 0, int offset = int.MaxValue)
		{
			List<Ticket> records = await this.TicketRepository.ByTicketStatusId(ticketStatusId, limit, offset);

			return this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0)
		{
			List<SaleTickets> records = await this.TicketRepository.SaleTickets(ticketId, limit, offset);

			return this.BolSaleTicketsMapper.MapBOToModel(this.DalSaleTicketsMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ba39b6b14c9603821ef72df6f485b3bd</Hash>
</Codenesium>*/