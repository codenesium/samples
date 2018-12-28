using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostLinkService : AbstractService
	{
		private IMediator mediator;

		protected IPostLinkRepository PostLinkRepository { get; private set; }

		protected IApiPostLinkServerRequestModelValidator PostLinkModelValidator { get; private set; }

		protected IBOLPostLinkMapper BolPostLinkMapper { get; private set; }

		protected IDALPostLinkMapper DalPostLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractPostLinkService(
			ILogger logger,
			IMediator mediator,
			IPostLinkRepository postLinkRepository,
			IApiPostLinkServerRequestModelValidator postLinkModelValidator,
			IBOLPostLinkMapper bolPostLinkMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base()
		{
			this.PostLinkRepository = postLinkRepository;
			this.PostLinkModelValidator = postLinkModelValidator;
			this.BolPostLinkMapper = bolPostLinkMapper;
			this.DalPostLinkMapper = dalPostLinkMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostLinkServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostLinkRepository.All(limit, offset);

			return this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostLinkServerResponseModel> Get(int id)
		{
			var record = await this.PostLinkRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostLinkServerResponseModel>> Create(
			ApiPostLinkServerRequestModel model)
		{
			CreateResponse<ApiPostLinkServerResponseModel> response = ValidationResponseFactory<ApiPostLinkServerResponseModel>.CreateResponse(await this.PostLinkModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostLinkMapper.MapModelToBO(default(int), model);
				var record = await this.PostLinkRepository.Create(this.DalPostLinkMapper.MapBOToEF(bo));

				var businessObject = this.DalPostLinkMapper.MapEFToBO(record);
				response.SetRecord(this.BolPostLinkMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new PostLinkCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostLinkServerResponseModel>> Update(
			int id,
			ApiPostLinkServerRequestModel model)
		{
			var validationResult = await this.PostLinkModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostLinkMapper.MapModelToBO(id, model);
				await this.PostLinkRepository.Update(this.DalPostLinkMapper.MapBOToEF(bo));

				var record = await this.PostLinkRepository.Get(id);

				var businessObject = this.DalPostLinkMapper.MapEFToBO(record);
				var apiModel = this.BolPostLinkMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new PostLinkUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostLinkServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostLinkServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostLinkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostLinkRepository.Delete(id);

				await this.mediator.Publish(new PostLinkDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>db8c2c11671c9d6c74fad51edc73b165</Hash>
</Codenesium>*/