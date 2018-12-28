using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractCommentService : AbstractService
	{
		private IMediator mediator;

		protected ICommentRepository CommentRepository { get; private set; }

		protected IApiCommentServerRequestModelValidator CommentModelValidator { get; private set; }

		protected IBOLCommentMapper BolCommentMapper { get; private set; }

		protected IDALCommentMapper DalCommentMapper { get; private set; }

		private ILogger logger;

		public AbstractCommentService(
			ILogger logger,
			IMediator mediator,
			ICommentRepository commentRepository,
			IApiCommentServerRequestModelValidator commentModelValidator,
			IBOLCommentMapper bolCommentMapper,
			IDALCommentMapper dalCommentMapper)
			: base()
		{
			this.CommentRepository = commentRepository;
			this.CommentModelValidator = commentModelValidator;
			this.BolCommentMapper = bolCommentMapper;
			this.DalCommentMapper = dalCommentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCommentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CommentRepository.All(limit, offset);

			return this.BolCommentMapper.MapBOToModel(this.DalCommentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCommentServerResponseModel> Get(int id)
		{
			var record = await this.CommentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCommentMapper.MapBOToModel(this.DalCommentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCommentServerResponseModel>> Create(
			ApiCommentServerRequestModel model)
		{
			CreateResponse<ApiCommentServerResponseModel> response = ValidationResponseFactory<ApiCommentServerResponseModel>.CreateResponse(await this.CommentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCommentMapper.MapModelToBO(default(int), model);
				var record = await this.CommentRepository.Create(this.DalCommentMapper.MapBOToEF(bo));

				var businessObject = this.DalCommentMapper.MapEFToBO(record);
				response.SetRecord(this.BolCommentMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCommentMapper.MapModelToBO(id, model);
				await this.CommentRepository.Update(this.DalCommentMapper.MapBOToEF(bo));

				var record = await this.CommentRepository.Get(id);

				var businessObject = this.DalCommentMapper.MapEFToBO(record);
				var apiModel = this.BolCommentMapper.MapBOToModel(businessObject);
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
	}
}

/*<Codenesium>
    <Hash>006a4d4b7f79d5794ce1e264718a9a50</Hash>
</Codenesium>*/