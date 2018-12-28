using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractVoteService : AbstractService
	{
		private IMediator mediator;

		protected IVoteRepository VoteRepository { get; private set; }

		protected IApiVoteServerRequestModelValidator VoteModelValidator { get; private set; }

		protected IBOLVoteMapper BolVoteMapper { get; private set; }

		protected IDALVoteMapper DalVoteMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteService(
			ILogger logger,
			IMediator mediator,
			IVoteRepository voteRepository,
			IApiVoteServerRequestModelValidator voteModelValidator,
			IBOLVoteMapper bolVoteMapper,
			IDALVoteMapper dalVoteMapper)
			: base()
		{
			this.VoteRepository = voteRepository;
			this.VoteModelValidator = voteModelValidator;
			this.BolVoteMapper = bolVoteMapper;
			this.DalVoteMapper = dalVoteMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVoteServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VoteRepository.All(limit, offset);

			return this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVoteServerResponseModel> Get(int id)
		{
			var record = await this.VoteRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVoteServerResponseModel>> Create(
			ApiVoteServerRequestModel model)
		{
			CreateResponse<ApiVoteServerResponseModel> response = ValidationResponseFactory<ApiVoteServerResponseModel>.CreateResponse(await this.VoteModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolVoteMapper.MapModelToBO(default(int), model);
				var record = await this.VoteRepository.Create(this.DalVoteMapper.MapBOToEF(bo));

				var businessObject = this.DalVoteMapper.MapEFToBO(record);
				response.SetRecord(this.BolVoteMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new VoteCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteServerResponseModel>> Update(
			int id,
			ApiVoteServerRequestModel model)
		{
			var validationResult = await this.VoteModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVoteMapper.MapModelToBO(id, model);
				await this.VoteRepository.Update(this.DalVoteMapper.MapBOToEF(bo));

				var record = await this.VoteRepository.Get(id);

				var businessObject = this.DalVoteMapper.MapEFToBO(record);
				var apiModel = this.BolVoteMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new VoteUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVoteServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVoteServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VoteRepository.Delete(id);

				await this.mediator.Publish(new VoteDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVoteServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Vote> records = await this.VoteRepository.ByUserId(userId, limit, offset);

			return this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f8391114b3a06ca4cc46b9d4ad71895c</Hash>
</Codenesium>*/