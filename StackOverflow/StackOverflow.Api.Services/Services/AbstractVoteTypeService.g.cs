using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractVoteTypeService : AbstractService
	{
		private IMediator mediator;

		protected IVoteTypeRepository VoteTypeRepository { get; private set; }

		protected IApiVoteTypeServerRequestModelValidator VoteTypeModelValidator { get; private set; }

		protected IBOLVoteTypeMapper BolVoteTypeMapper { get; private set; }

		protected IDALVoteTypeMapper DalVoteTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteTypeService(
			ILogger logger,
			IMediator mediator,
			IVoteTypeRepository voteTypeRepository,
			IApiVoteTypeServerRequestModelValidator voteTypeModelValidator,
			IBOLVoteTypeMapper bolVoteTypeMapper,
			IDALVoteTypeMapper dalVoteTypeMapper)
			: base()
		{
			this.VoteTypeRepository = voteTypeRepository;
			this.VoteTypeModelValidator = voteTypeModelValidator;
			this.BolVoteTypeMapper = bolVoteTypeMapper;
			this.DalVoteTypeMapper = dalVoteTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVoteTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VoteTypeRepository.All(limit, offset);

			return this.BolVoteTypeMapper.MapBOToModel(this.DalVoteTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVoteTypeServerResponseModel> Get(int id)
		{
			var record = await this.VoteTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVoteTypeMapper.MapBOToModel(this.DalVoteTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVoteTypeServerResponseModel>> Create(
			ApiVoteTypeServerRequestModel model)
		{
			CreateResponse<ApiVoteTypeServerResponseModel> response = ValidationResponseFactory<ApiVoteTypeServerResponseModel>.CreateResponse(await this.VoteTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolVoteTypeMapper.MapModelToBO(default(int), model);
				var record = await this.VoteTypeRepository.Create(this.DalVoteTypeMapper.MapBOToEF(bo));

				var businessObject = this.DalVoteTypeMapper.MapEFToBO(record);
				response.SetRecord(this.BolVoteTypeMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new VoteTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteTypeServerResponseModel>> Update(
			int id,
			ApiVoteTypeServerRequestModel model)
		{
			var validationResult = await this.VoteTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVoteTypeMapper.MapModelToBO(id, model);
				await this.VoteTypeRepository.Update(this.DalVoteTypeMapper.MapBOToEF(bo));

				var record = await this.VoteTypeRepository.Get(id);

				var businessObject = this.DalVoteTypeMapper.MapEFToBO(record);
				var apiModel = this.BolVoteTypeMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new VoteTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVoteTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVoteTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VoteTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VoteTypeRepository.Delete(id);

				await this.mediator.Publish(new VoteTypeDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc07226b85acd3c60fed8a47c68c1be8</Hash>
</Codenesium>*/