using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostTypeService : AbstractService, IPostTypeService
	{
		private MediatR.IMediator mediator;

		protected IPostTypeRepository PostTypeRepository { get; private set; }

		protected IApiPostTypeServerRequestModelValidator PostTypeModelValidator { get; private set; }

		protected IDALPostTypeMapper DalPostTypeMapper { get; private set; }

		protected IDALPostMapper DalPostMapper { get; private set; }

		private ILogger logger;

		public PostTypeService(
			ILogger<IPostTypeService> logger,
			MediatR.IMediator mediator,
			IPostTypeRepository postTypeRepository,
			IApiPostTypeServerRequestModelValidator postTypeModelValidator,
			IDALPostTypeMapper dalPostTypeMapper,
			IDALPostMapper dalPostMapper)
			: base()
		{
			this.PostTypeRepository = postTypeRepository;
			this.PostTypeModelValidator = postTypeModelValidator;
			this.DalPostTypeMapper = dalPostTypeMapper;
			this.DalPostMapper = dalPostMapper;
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

		public async virtual Task<List<ApiPostServerResponseModel>> PostsByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<Post> records = await this.PostTypeRepository.PostsByPostTypeId(postTypeId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>4d84bfabddc12ce5b2ba914ab890e04b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/