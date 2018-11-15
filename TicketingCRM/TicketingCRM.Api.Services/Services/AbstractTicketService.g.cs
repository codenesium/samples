using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractTicketService : AbstractService
	{
		protected ITicketRepository TicketRepository { get; private set; }

		protected IApiTicketServerRequestModelValidator TicketModelValidator { get; private set; }

		protected IBOLTicketMapper BolTicketMapper { get; private set; }

		protected IDALTicketMapper DalTicketMapper { get; private set; }

		private ILogger logger;

		public AbstractTicketService(
			ILogger logger,
			ITicketRepository ticketRepository,
			IApiTicketServerRequestModelValidator ticketModelValidator,
			IBOLTicketMapper bolTicketMapper,
			IDALTicketMapper dalTicketMapper)
			: base()
		{
			this.TicketRepository = ticketRepository;
			this.TicketModelValidator = ticketModelValidator;
			this.BolTicketMapper = bolTicketMapper;
			this.DalTicketMapper = dalTicketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTicketServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TicketRepository.All(limit, offset);

			return this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTicketServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiTicketServerResponseModel>> Create(
			ApiTicketServerRequestModel model)
		{
			CreateResponse<ApiTicketServerResponseModel> response = ValidationResponseFactory<ApiTicketServerResponseModel>.CreateResponse(await this.TicketModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTicketMapper.MapModelToBO(default(int), model);
				var record = await this.TicketRepository.Create(this.DalTicketMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTicketServerResponseModel>> Update(
			int id,
			ApiTicketServerRequestModel model)
		{
			var validationResult = await this.TicketModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTicketMapper.MapModelToBO(id, model);
				await this.TicketRepository.Update(this.DalTicketMapper.MapBOToEF(bo));

				var record = await this.TicketRepository.Get(id);

				return ValidationResponseFactory<ApiTicketServerResponseModel>.UpdateResponse(this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiTicketServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TicketModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TicketRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiTicketServerResponseModel>> ByTicketStatusId(int ticketStatusId, int limit = 0, int offset = int.MaxValue)
		{
			List<Ticket> records = await this.TicketRepository.ByTicketStatusId(ticketStatusId, limit, offset);

			return this.BolTicketMapper.MapBOToModel(this.DalTicketMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>babd4a79c5d6ee4a86b798c7b3a60bf6</Hash>
</Codenesium>*/