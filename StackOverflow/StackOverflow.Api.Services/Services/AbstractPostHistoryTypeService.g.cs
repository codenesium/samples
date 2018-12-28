using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostHistoryTypeService : AbstractService
	{
		private IMediator mediator;

		protected IPostHistoryTypeRepository PostHistoryTypeRepository { get; private set; }

		protected IApiPostHistoryTypeServerRequestModelValidator PostHistoryTypeModelValidator { get; private set; }

		protected IBOLPostHistoryTypeMapper BolPostHistoryTypeMapper { get; private set; }

		protected IDALPostHistoryTypeMapper DalPostHistoryTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryTypeService(
			ILogger logger,
			IMediator mediator,
			IPostHistoryTypeRepository postHistoryTypeRepository,
			IApiPostHistoryTypeServerRequestModelValidator postHistoryTypeModelValidator,
			IBOLPostHistoryTypeMapper bolPostHistoryTypeMapper,
			IDALPostHistoryTypeMapper dalPostHistoryTypeMapper)
			: base()
		{
			this.PostHistoryTypeRepository = postHistoryTypeRepository;
			this.PostHistoryTypeModelValidator = postHistoryTypeModelValidator;
			this.BolPostHistoryTypeMapper = bolPostHistoryTypeMapper;
			this.DalPostHistoryTypeMapper = dalPostHistoryTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostHistoryTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostHistoryTypeRepository.All(limit, offset);

			return this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryTypeServerResponseModel> Get(int id)
		{
			var record = await this.PostHistoryTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypeServerResponseModel>> Create(
			ApiPostHistoryTypeServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypeServerResponseModel> response = ValidationResponseFactory<ApiPostHistoryTypeServerResponseModel>.CreateResponse(await this.PostHistoryTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostHistoryTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PostHistoryTypeRepository.Create(this.DalPostHistoryTypeMapper.MapBOToEF(bo));

				var businessObject = this.DalPostHistoryTypeMapper.MapEFToBO(record);
				response.SetRecord(this.BolPostHistoryTypeMapper.MapBOToModel(businessObject));
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
				var bo = this.BolPostHistoryTypeMapper.MapModelToBO(id, model);
				await this.PostHistoryTypeRepository.Update(this.DalPostHistoryTypeMapper.MapBOToEF(bo));

				var record = await this.PostHistoryTypeRepository.Get(id);

				var businessObject = this.DalPostHistoryTypeMapper.MapEFToBO(record);
				var apiModel = this.BolPostHistoryTypeMapper.MapBOToModel(businessObject);
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
	}
}

/*<Codenesium>
    <Hash>7cd79b45ec66545c6854d863ce39c25f</Hash>
</Codenesium>*/