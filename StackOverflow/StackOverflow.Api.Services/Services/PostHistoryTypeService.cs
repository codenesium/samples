using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostHistoryTypeService : AbstractService, IPostHistoryTypeService
	{
		private MediatR.IMediator mediator;

		protected IPostHistoryTypeRepository PostHistoryTypeRepository { get; private set; }

		protected IApiPostHistoryTypeServerRequestModelValidator PostHistoryTypeModelValidator { get; private set; }

		protected IDALPostHistoryTypeMapper DalPostHistoryTypeMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public PostHistoryTypeService(
			ILogger<IPostHistoryTypeService> logger,
			MediatR.IMediator mediator,
			IPostHistoryTypeRepository postHistoryTypeRepository,
			IApiPostHistoryTypeServerRequestModelValidator postHistoryTypeModelValidator,
			IDALPostHistoryTypeMapper dalPostHistoryTypeMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.PostHistoryTypeRepository = postHistoryTypeRepository;
			this.PostHistoryTypeModelValidator = postHistoryTypeModelValidator;
			this.DalPostHistoryTypeMapper = dalPostHistoryTypeMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostHistoryTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PostHistoryType> records = await this.PostHistoryTypeRepository.All(limit, offset, query);

			return this.DalPostHistoryTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostHistoryTypeServerResponseModel> Get(int id)
		{
			PostHistoryType record = await this.PostHistoryTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostHistoryTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypeServerResponseModel>> Create(
			ApiPostHistoryTypeServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypeServerResponseModel> response = ValidationResponseFactory<ApiPostHistoryTypeServerResponseModel>.CreateResponse(await this.PostHistoryTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PostHistoryType record = this.DalPostHistoryTypeMapper.MapModelToEntity(default(int), model);
				record = await this.PostHistoryTypeRepository.Create(record);

				response.SetRecord(this.DalPostHistoryTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostHistoryTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypeServerResponseModel>> Update(
			int id,
			ApiPostHistoryTypeServerRequestModel model)
		{
			var validationResult = await this.PostHistoryTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PostHistoryType record = this.DalPostHistoryTypeMapper.MapModelToEntity(id, model);
				await this.PostHistoryTypeRepository.Update(record);

				record = await this.PostHistoryTypeRepository.Get(id);

				ApiPostHistoryTypeServerResponseModel apiModel = this.DalPostHistoryTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostHistoryTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostHistoryTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostHistoryTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostHistoryTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostHistoryTypeRepository.Delete(id);

				await this.mediator.Publish(new PostHistoryTypeDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> PostHistoriesByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostHistory> records = await this.PostHistoryTypeRepository.PostHistoriesByPostHistoryTypeId(postHistoryTypeId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>a69c5e4cd09c1e9dd17127c7bf816810</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/