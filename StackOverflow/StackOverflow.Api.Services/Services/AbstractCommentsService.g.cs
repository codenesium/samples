using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractCommentsService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICommentsRepository CommentsRepository { get; private set; }

		protected IApiCommentsServerRequestModelValidator CommentsModelValidator { get; private set; }

		protected IDALCommentsMapper DalCommentsMapper { get; private set; }

		private ILogger logger;

		public AbstractCommentsService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICommentsRepository commentsRepository,
			IApiCommentsServerRequestModelValidator commentsModelValidator,
			IDALCommentsMapper dalCommentsMapper)
			: base()
		{
			this.CommentsRepository = commentsRepository;
			this.CommentsModelValidator = commentsModelValidator;
			this.DalCommentsMapper = dalCommentsMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCommentsServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Comments> records = await this.CommentsRepository.All(limit, offset, query);

			return this.DalCommentsMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCommentsServerResponseModel> Get(int id)
		{
			Comments record = await this.CommentsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCommentsMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCommentsServerResponseModel>> Create(
			ApiCommentsServerRequestModel model)
		{
			CreateResponse<ApiCommentsServerResponseModel> response = ValidationResponseFactory<ApiCommentsServerResponseModel>.CreateResponse(await this.CommentsModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Comments record = this.DalCommentsMapper.MapModelToEntity(default(int), model);
				record = await this.CommentsRepository.Create(record);

				response.SetRecord(this.DalCommentsMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CommentsCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCommentsServerResponseModel>> Update(
			int id,
			ApiCommentsServerRequestModel model)
		{
			var validationResult = await this.CommentsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Comments record = this.DalCommentsMapper.MapModelToEntity(id, model);
				await this.CommentsRepository.Update(record);

				record = await this.CommentsRepository.Get(id);

				ApiCommentsServerResponseModel apiModel = this.DalCommentsMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CommentsUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCommentsServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCommentsServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CommentsModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CommentsRepository.Delete(id);

				await this.mediator.Publish(new CommentsDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCommentsServerResponseModel>> ByPostId(int postId, int limit = 0, int offset = int.MaxValue)
		{
			List<Comments> records = await this.CommentsRepository.ByPostId(postId, limit, offset);

			return this.DalCommentsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCommentsServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Comments> records = await this.CommentsRepository.ByUserId(userId, limit, offset);

			return this.DalCommentsMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>6662e0f491dd208f9f5f934a97a127bb</Hash>
</Codenesium>*/