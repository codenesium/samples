using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSpecialOfferService : AbstractService
	{
		private IMediator mediator;

		protected ISpecialOfferRepository SpecialOfferRepository { get; private set; }

		protected IApiSpecialOfferServerRequestModelValidator SpecialOfferModelValidator { get; private set; }

		protected IDALSpecialOfferMapper DalSpecialOfferMapper { get; private set; }

		private ILogger logger;

		public AbstractSpecialOfferService(
			ILogger logger,
			IMediator mediator,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferServerRequestModelValidator specialOfferModelValidator,
			IDALSpecialOfferMapper dalSpecialOfferMapper)
			: base()
		{
			this.SpecialOfferRepository = specialOfferRepository;
			this.SpecialOfferModelValidator = specialOfferModelValidator;
			this.DalSpecialOfferMapper = dalSpecialOfferMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpecialOfferServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.SpecialOfferRepository.All(limit, offset, query);

			return this.DalSpecialOfferMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiSpecialOfferServerResponseModel> Get(int specialOfferID)
		{
			var record = await this.SpecialOfferRepository.Get(specialOfferID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSpecialOfferMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferServerResponseModel>> Create(
			ApiSpecialOfferServerRequestModel model)
		{
			CreateResponse<ApiSpecialOfferServerResponseModel> response = ValidationResponseFactory<ApiSpecialOfferServerResponseModel>.CreateResponse(await this.SpecialOfferModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalSpecialOfferMapper.MapModelToBO(default(int), model);
				var record = await this.SpecialOfferRepository.Create(bo);

				response.SetRecord(this.DalSpecialOfferMapper.MapBOToModel(record));
				await this.mediator.Publish(new SpecialOfferCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpecialOfferServerResponseModel>> Update(
			int specialOfferID,
			ApiSpecialOfferServerRequestModel model)
		{
			var validationResult = await this.SpecialOfferModelValidator.ValidateUpdateAsync(specialOfferID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalSpecialOfferMapper.MapModelToBO(specialOfferID, model);
				await this.SpecialOfferRepository.Update(bo);

				var record = await this.SpecialOfferRepository.Get(specialOfferID);

				var apiModel = this.DalSpecialOfferMapper.MapBOToModel(record);
				await this.mediator.Publish(new SpecialOfferUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSpecialOfferServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSpecialOfferServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SpecialOfferModelValidator.ValidateDeleteAsync(specialOfferID));

			if (response.Success)
			{
				await this.SpecialOfferRepository.Delete(specialOfferID);

				await this.mediator.Publish(new SpecialOfferDeletedNotification(specialOfferID));
			}

			return response;
		}

		public async virtual Task<ApiSpecialOfferServerResponseModel> ByRowguid(Guid rowguid)
		{
			SpecialOffer record = await this.SpecialOfferRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSpecialOfferMapper.MapBOToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>fe7a31cd72a42edf7605ac25462ece1f</Hash>
</Codenesium>*/