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
		protected ITicketStatusRepository TicketStatusRepository { get; private set; }

		protected IApiTicketStatusRequestModelValidator TicketStatusModelValidator { get; private set; }

		protected IBOLTicketStatusMapper BolTicketStatusMapper { get; private set; }

		protected IDALTicketStatusMapper DalTicketStatusMapper { get; private set; }

		protected IBOLTicketMapper BolTicketMapper { get; private set; }

		protected IDALTicketMapper DalTicketMapper { get; private set; }

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
			this.TicketStatusRepository = ticketStatusRepository;
			this.TicketStatusModelValidator = ticketStatusModelValidator;
			this.BolTicketStatusMapper = bolTicketStatusMapper;
			this.DalTicketStatusMapper = dalTicketStatusMapper;
			this.BolTicketMapper = bolTicketMapper;
			this.DalTicketMapper = dalTicketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTicketStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TicketStatusRepository.All(limit, offset);

			return this.BolTicketStatusMapper.MapBOToModel(this.DalTicketStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTicketStatusResponseModel> Get(int id)
		{
			var record = await this.TicketStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTicketStatusMapper.MapBOToModel(this.DalTicketStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTicketStatusResponseModel>> Create(
			ApiTicketStatusRequestModel model)
		{
			CreateResponse<ApiTicketStatusResponseModel> response = new CreateResponse<ApiTicketStatusResponseModel>(await this.TicketStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTicketStatusMapper.MapModelToBO(default(int), model);
				var record = await this.TicketStatusRepository.Create(this.DalTicketStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTicketStatusMapper.MapBOToModel(this.DalTicketStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketStatusResponseModel>> Update(
			int id,
			ApiTicketStatusRequestModel model)
		{
			var validationResult = await this.TicketStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTicketStatusMapper.MapModelToBO(id, model);
				await this.TicketStatusRepository.Update(this.DalTicketStatusMapper.MapBOToEF(bo));

				var record = await this.TicketStatusRepository.Get(id);

				return new UpdateResponse<ApiTicketStatusResponseModel>(this.BolTicketStatusMapper.MapBOToModel(this.DalTicketStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTicketStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TicketStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TicketStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Ticket> records = await this.TicketStatusRepository.Tickets(ticketStatusId, limit, offset);

			return this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2d72eb30675a9f5bc8ff135d8010e0ac</Hash>
</Codenesium>*/