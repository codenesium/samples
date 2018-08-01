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
	public abstract class AbstractTicketStatusService : AbstractService
	{
		private ITicketStatusRepository ticketStatusRepository;

		private IApiTicketStatusRequestModelValidator ticketStatusModelValidator;

		private IBOLTicketStatusMapper bolTicketStatusMapper;

		private IDALTicketStatusMapper dalTicketStatusMapper;

		private IBOLTicketMapper bolTicketMapper;

		private IDALTicketMapper dalTicketMapper;

		private ILogger logger;

		public AbstractTicketStatusService(
			ILogger logger,
			ITicketStatusRepository ticketStatusRepository,
			IApiTicketStatusRequestModelValidator ticketStatusModelValidator,
			IBOLTicketStatusMapper bolTicketStatusMapper,
			IDALTicketStatusMapper dalTicketStatusMapper,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper)
			: base()
		{
			this.ticketStatusRepository = ticketStatusRepository;
			this.ticketStatusModelValidator = ticketStatusModelValidator;
			this.bolTicketStatusMapper = bolTicketStatusMapper;
			this.dalTicketStatusMapper = dalTicketStatusMapper;
			this.bolTicketMapper = bolTicketMapper;
			this.dalTicketMapper = dalTicketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTicketStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ticketStatusRepository.All(limit, offset);

			return this.bolTicketStatusMapper.MapBOToModel(this.dalTicketStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTicketStatusResponseModel> Get(int id)
		{
			var record = await this.ticketStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolTicketStatusMapper.MapBOToModel(this.dalTicketStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTicketStatusResponseModel>> Create(
			ApiTicketStatusRequestModel model)
		{
			CreateResponse<ApiTicketStatusResponseModel> response = new CreateResponse<ApiTicketStatusResponseModel>(await this.ticketStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolTicketStatusMapper.MapModelToBO(default(int), model);
				var record = await this.ticketStatusRepository.Create(this.dalTicketStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.bolTicketStatusMapper.MapBOToModel(this.dalTicketStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketStatusResponseModel>> Update(
			int id,
			ApiTicketStatusRequestModel model)
		{
			var validationResult = await this.ticketStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolTicketStatusMapper.MapModelToBO(id, model);
				await this.ticketStatusRepository.Update(this.dalTicketStatusMapper.MapBOToEF(bo));

				var record = await this.ticketStatusRepository.Get(id);

				return new UpdateResponse<ApiTicketStatusResponseModel>(this.bolTicketStatusMapper.MapBOToModel(this.dalTicketStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTicketStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ticketStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ticketStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Ticket> records = await this.ticketStatusRepository.Tickets(ticketStatusId, limit, offset);

			return this.bolTicketMapper.MapBOToModel(this.dalTicketMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>acb5fbd20c118cd647c741268d2d5463</Hash>
</Codenesium>*/