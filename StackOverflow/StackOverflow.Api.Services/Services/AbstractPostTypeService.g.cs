using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostTypeService : AbstractService
	{
		private IMediator mediator;

		protected IPostTypeRepository PostTypeRepository { get; private set; }

		protected IApiPostTypeServerRequestModelValidator PostTypeModelValidator { get; private set; }

		protected IDALPostTypeMapper DalPostTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPostTypeService(
			ILogger logger,
			IMediator mediator,
			IPostTypeRepository postTypeRepository,
			IApiPostTypeServerRequestModelValidator postTypeModelValidator,
			IDALPostTypeMapper dalPostTypeMapper)
			: base()
		{
			this.PostTypeRepository = postTypeRepository;
			this.PostTypeModelValidator = postTypeModelValidator;
			this.DalPostTypeMapper = dalPostTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PostType> records = await this.PostTypeRepository.All(limit, offset, query);

			return this.DalPostTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostTypeServerResponseModel> Get(int id)
		{
			PostType record = await this.PostTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostTypeServerResponseModel>> Create(
			ApiPostTypeServerRequestModel model)
		{
			CreateResponse<ApiPostTypeServerResponseModel> response = ValidationResponseFactory<ApiPostTypeServerResponseModel>.CreateResponse(await this.PostTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PostType record = this.DalPostTypeMapper.MapModelToEntity(default(int), model);
				record = await this.PostTypeRepository.Create(record);

				response.SetRecord(this.DalPostTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostTypeServerResponseModel>> Update(
			int id,
			ApiPostTypeServerRequestModel model)
		{
			var validationResult = await this.PostTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PostType record = this.DalPostTypeMapper.MapModelToEntity(id, model);
				await this.PostTypeRepository.Update(record);

				record = await this.PostTypeRepository.Get(id);

				ApiPostTypeServerResponseModel apiModel = this.DalPostTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostTypeRepository.Delete(id);

				await this.mediator.Publish(new PostTypeDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1d8b852a2a0904be3911586363b1d34d</Hash>
</Codenesium>*/