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

		protected IBOLPostTypeMapper BolPostTypeMapper { get; private set; }

		protected IDALPostTypeMapper DalPostTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPostTypeService(
			ILogger logger,
			IMediator mediator,
			IPostTypeRepository postTypeRepository,
			IApiPostTypeServerRequestModelValidator postTypeModelValidator,
			IBOLPostTypeMapper bolPostTypeMapper,
			IDALPostTypeMapper dalPostTypeMapper)
			: base()
		{
			this.PostTypeRepository = postTypeRepository;
			this.PostTypeModelValidator = postTypeModelValidator;
			this.BolPostTypeMapper = bolPostTypeMapper;
			this.DalPostTypeMapper = dalPostTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostTypeRepository.All(limit, offset);

			return this.BolPostTypeMapper.MapBOToModel(this.DalPostTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostTypeServerResponseModel> Get(int id)
		{
			var record = await this.PostTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostTypeMapper.MapBOToModel(this.DalPostTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostTypeServerResponseModel>> Create(
			ApiPostTypeServerRequestModel model)
		{
			CreateResponse<ApiPostTypeServerResponseModel> response = ValidationResponseFactory<ApiPostTypeServerResponseModel>.CreateResponse(await this.PostTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PostTypeRepository.Create(this.DalPostTypeMapper.MapBOToEF(bo));

				var businessObject = this.DalPostTypeMapper.MapEFToBO(record);
				response.SetRecord(this.BolPostTypeMapper.MapBOToModel(businessObject));
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
				var bo = this.BolPostTypeMapper.MapModelToBO(id, model);
				await this.PostTypeRepository.Update(this.DalPostTypeMapper.MapBOToEF(bo));

				var record = await this.PostTypeRepository.Get(id);

				var businessObject = this.DalPostTypeMapper.MapEFToBO(record);
				var apiModel = this.BolPostTypeMapper.MapBOToModel(businessObject);
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
    <Hash>a29a25a1b26bb79461723d1d6e50c57a</Hash>
</Codenesium>*/