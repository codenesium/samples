using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class CommentService : AbstractService, ICommentService
	{
		private MediatR.IMediator mediator;

		protected ICommentRepository CommentRepository { get; private set; }

		protected IApiCommentServerRequestModelValidator CommentModelValidator { get; private set; }

		protected IDALCommentMapper DalCommentMapper { get; private set; }

		private ILogger logger;

		public CommentService(
			ILogger<ICommentService> logger,
			MediatR.IMediator mediator,
			ICommentRepository commentRepository,
			IApiCommentServerRequestModelValidator commentModelValidator,
			IDALCommentMapper dalCommentMapper)
			: base()
		{
			this.CommentRepository = commentRepository;
			this.CommentModelValidator = commentModelValidator;
			this.DalCommentMapper = dalCommentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCommentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Comment> records = await this.CommentRepository.All(limit, offset, query);

			return this.DalCommentMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCommentServerResponseModel> Get(int id)
		{
			Comment record = await this.CommentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCommentMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCommentServerResponseModel>> Create(
			ApiCommentServerRequestModel model)
		{
			CreateResponse<ApiCommentServerResponseModel> response = ValidationResponseFactory<ApiCommentServerResponseModel>.CreateResponse(await this.CommentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Comment record = this.DalCommentMapper.MapModelToEntity(default(int), model);
				record = await this.CommentRepository.Create(record);

				response.SetRecord(this.DalCommentMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CommentCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCommentServerResponseModel>> Update(
			int id,
			ApiCommentServerRequestModel model)
		{
			var validationResult = await this.CommentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Comment record = this.DalCommentMapper.MapModelToEntity(id, model);
				await this.CommentRepository.Update(record);

				record = await this.CommentRepository.Get(id);

				ApiCommentServerResponseModel apiModel = this.DalCommentMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CommentUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCommentServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCommentServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CommentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CommentRepository.Delete(id);

				await this.mediator.Publish(new CommentDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCommentServerResponseModel>> ByPostId(int postId, int limit = 0, int offset = int.MaxValue)
		{
			List<Comment> records = await this.CommentRepository.ByPostId(postId, limit, offset);

			return this.DalCommentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCommentServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Comment> records = await this.CommentRepository.ByUserId(userId, limit, offset);

			return this.DalCommentMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>0c880cd857560f2c4b0fa0322cf7739e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/