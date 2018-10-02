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
	public abstract class AbstractTicketStatuService : AbstractService
	{
		protected ITicketStatuRepository TicketStatuRepository { get; private set; }

		protected IApiTicketStatuRequestModelValidator TicketStatuModelValidator { get; private set; }

		protected IBOLTicketStatuMapper BolTicketStatuMapper { get; private set; }

		protected IDALTicketStatuMapper DalTicketStatuMapper { get; private set; }

		protected IBOLTicketMapper BolTicketMapper { get; private set; }

		protected IDALTicketMapper DalTicketMapper { get; private set; }

		private ILogger logger;

		public AbstractTicketStatuService(
			ILogger logger,
			ITicketStatuRepository ticketStatuRepository,
			IApiTicketStatuRequestModelValidator ticketStatuModelValidator,
			IBOLTicketStatuMapper bolTicketStatuMapper,
			IDALTicketStatuMapper dalTicketStatuMapper,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper)
			: base()
		{
			this.TicketStatuRepository = ticketStatuRepository;
			this.TicketStatuModelValidator = ticketStatuModelValidator;
			this.BolTicketStatuMapper = bolTicketStatuMapper;
			this.DalTicketStatuMapper = dalTicketStatuMapper;
			this.BolTicketMapper = bolTicketMapper;
			this.DalTicketMapper = dalTicketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTicketStatuResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TicketStatuRepository.All(limit, offset);

			return this.BolTicketStatuMapper.MapBOToModel(this.DalTicketStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTicketStatuResponseModel> Get(int id)
		{
			var record = await this.TicketStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTicketStatuMapper.MapBOToModel(this.DalTicketStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTicketStatuResponseModel>> Create(
			ApiTicketStatuRequestModel model)
		{
			CreateResponse<ApiTicketStatuResponseModel> response = new CreateResponse<ApiTicketStatuResponseModel>(await this.TicketStatuModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTicketStatuMapper.MapModelToBO(default(int), model);
				var record = await this.TicketStatuRepository.Create(this.DalTicketStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTicketStatuMapper.MapBOToModel(this.DalTicketStatuMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketStatuResponseModel>> Update(
			int id,
			ApiTicketStatuRequestModel model)
		{
			var validationResult = await this.TicketStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTicketStatuMapper.MapModelToBO(id, model);
				await this.TicketStatuRepository.Update(this.DalTicketStatuMapper.MapBOToEF(bo));

				var record = await this.TicketStatuRepository.Get(id);

				return new UpdateResponse<ApiTicketStatuResponseModel>(this.BolTicketStatuMapper.MapBOToModel(this.DalTicketStatuMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTicketStatuResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TicketStatuModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TicketStatuRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Ticket> records = await this.TicketStatuRepository.Tickets(ticketStatusId, limit, offset);

			return this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>31c35cefee77148741b28142ca73c013</Hash>
</Codenesium>*/