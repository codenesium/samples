using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSpecialOfferService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ISpecialOfferRepository SpecialOfferRepository { get; private set; }

		protected IApiSpecialOfferServerRequestModelValidator SpecialOfferModelValidator { get; private set; }

		protected IDALSpecialOfferMapper DalSpecialOfferMapper { get; private set; }

		private ILogger logger;

		public AbstractSpecialOfferService(
			ILogger logger,
			MediatR.IMediator mediator,
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
			List<SpecialOffer> records = await this.SpecialOfferRepository.All(limit, offset, query);

			return this.DalSpecialOfferMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSpecialOfferServerResponseModel> Get(int specialOfferID)
		{
			SpecialOffer record = await this.SpecialOfferRepository.Get(specialOfferID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSpecialOfferMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferServerResponseModel>> Create(
			ApiSpecialOfferServerRequestModel model)
		{
			CreateResponse<ApiSpecialOfferServerResponseModel> response = ValidationResponseFactory<ApiSpecialOfferServerResponseModel>.CreateResponse(await this.SpecialOfferModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SpecialOffer record = this.DalSpecialOfferMapper.MapModelToEntity(default(int), model);
				record = await this.SpecialOfferRepository.Create(record);

				response.SetRecord(this.DalSpecialOfferMapper.MapEntityToModel(record));
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
				SpecialOffer record = this.DalSpecialOfferMapper.MapModelToEntity(specialOfferID, model);
				await this.SpecialOfferRepository.Update(record);

				record = await this.SpecialOfferRepository.Get(specialOfferID);

				ApiSpecialOfferServerResponseModel apiModel = this.DalSpecialOfferMapper.MapEntityToModel(record);
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
				return this.DalSpecialOfferMapper.MapEntityToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>e143e29f3cb74d3234b8a5be8796f691</Hash>
</Codenesium>*/