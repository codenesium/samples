using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ChainStatusService : AbstractService, IChainStatusService
	{
		private MediatR.IMediator mediator;

		protected IChainStatusRepository ChainStatusRepository { get; private set; }

		protected IApiChainStatusServerRequestModelValidator ChainStatusModelValidator { get; private set; }

		protected IDALChainStatusMapper DalChainStatusMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		private ILogger logger;

		public ChainStatusService(
			ILogger<IChainStatusService> logger,
			MediatR.IMediator mediator,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusServerRequestModelValidator chainStatusModelValidator,
			IDALChainStatusMapper dalChainStatusMapper,
			IDALChainMapper dalChainMapper)
			: base()
		{
			this.ChainStatusRepository = chainStatusRepository;
			this.ChainStatusModelValidator = chainStatusModelValidator;
			this.DalChainStatusMapper = dalChainStatusMapper;
			this.DalChainMapper = dalChainMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiChainStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ChainStatus> records = await this.ChainStatusRepository.All(limit, offset, query);

			return this.DalChainStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiChainStatusServerResponseModel> Get(int id)
		{
			ChainStatus record = await this.ChainStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalChainStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiChainStatusServerResponseModel>> Create(
			ApiChainStatusServerRequestModel model)
		{
			CreateResponse<ApiChainStatusServerResponseModel> response = ValidationResponseFactory<ApiChainStatusServerResponseModel>.CreateResponse(await this.ChainStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ChainStatus record = this.DalChainStatusMapper.MapModelToEntity(default(int), model);
				record = await this.ChainStatusRepository.Create(record);

				response.SetRecord(this.DalChainStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ChainStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiChainStatusServerResponseModel>> Update(
			int id,
			ApiChainStatusServerRequestModel model)
		{
			var validationResult = await this.ChainStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				ChainStatus record = this.DalChainStatusMapper.MapModelToEntity(id, model);
				await this.ChainStatusRepository.Update(record);

				record = await this.ChainStatusRepository.Get(id);

				ApiChainStatusServerResponseModel apiModel = this.DalChainStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ChainStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiChainStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiChainStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ChainStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ChainStatusRepository.Delete(id);

				await this.mediator.Publish(new ChainStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiChainStatusServerResponseModel> ByName(string name)
		{
			ChainStatus record = await this.ChainStatusRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalChainStatusMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiChainServerResponseModel>> ChainsByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.ChainStatusRepository.ChainsByChainStatusId(chainStatusId, limit, offset);

			return this.DalChainMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>c2f429385d2753c06e39d12b66973a70</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/