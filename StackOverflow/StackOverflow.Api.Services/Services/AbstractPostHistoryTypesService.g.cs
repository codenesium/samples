using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostHistoryTypesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPostHistoryTypesRepository PostHistoryTypesRepository { get; private set; }

		protected IApiPostHistoryTypesServerRequestModelValidator PostHistoryTypesModelValidator { get; private set; }

		protected IDALPostHistoryTypesMapper DalPostHistoryTypesMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryTypesService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPostHistoryTypesRepository postHistoryTypesRepository,
			IApiPostHistoryTypesServerRequestModelValidator postHistoryTypesModelValidator,
			IDALPostHistoryTypesMapper dalPostHistoryTypesMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.PostHistoryTypesRepository = postHistoryTypesRepository;
			this.PostHistoryTypesModelValidator = postHistoryTypesModelValidator;
			this.DalPostHistoryTypesMapper = dalPostHistoryTypesMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostHistoryTypesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PostHistoryTypes> records = await this.PostHistoryTypesRepository.All(limit, offset, query);

			return this.DalPostHistoryTypesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostHistoryTypesServerResponseModel> Get(int id)
		{
			PostHistoryTypes record = await this.PostHistoryTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostHistoryTypesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypesServerResponseModel>> Create(
			ApiPostHistoryTypesServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypesServerResponseModel> response = ValidationResponseFactory<ApiPostHistoryTypesServerResponseModel>.CreateResponse(await this.PostHistoryTypesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PostHistoryTypes record = this.DalPostHistoryTypesMapper.MapModelToEntity(default(int), model);
				record = await this.PostHistoryTypesRepository.Create(record);

				response.SetRecord(this.DalPostHistoryTypesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostHistoryTypesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypesServerResponseModel>> Update(
			int id,
			ApiPostHistoryTypesServerRequestModel model)
		{
			var validationResult = await this.PostHistoryTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PostHistoryTypes record = this.DalPostHistoryTypesMapper.MapModelToEntity(id, model);
				await this.PostHistoryTypesRepository.Update(record);

				record = await this.PostHistoryTypesRepository.Get(id);

				ApiPostHistoryTypesServerResponseModel apiModel = this.DalPostHistoryTypesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostHistoryTypesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostHistoryTypesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostHistoryTypesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostHistoryTypesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostHistoryTypesRepository.Delete(id);

				await this.mediator.Publish(new PostHistoryTypesDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> PostHistoryByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostHistory> records = await this.PostHistoryTypesRepository.PostHistoryByPostHistoryTypeId(postHistoryTypeId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f271a21c7e84536caefef5cdfd858770</Hash>
</Codenesium>*/