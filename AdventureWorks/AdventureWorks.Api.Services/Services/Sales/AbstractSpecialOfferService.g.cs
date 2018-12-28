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

		protected IBOLSpecialOfferMapper BolSpecialOfferMapper { get; private set; }

		protected IDALSpecialOfferMapper DalSpecialOfferMapper { get; private set; }

		private ILogger logger;

		public AbstractSpecialOfferService(
			ILogger logger,
			IMediator mediator,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferServerRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper bolSpecialOfferMapper,
			IDALSpecialOfferMapper dalSpecialOfferMapper)
			: base()
		{
			this.SpecialOfferRepository = specialOfferRepository;
			this.SpecialOfferModelValidator = specialOfferModelValidator;
			this.BolSpecialOfferMapper = bolSpecialOfferMapper;
			this.DalSpecialOfferMapper = dalSpecialOfferMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpecialOfferServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpecialOfferRepository.All(limit, offset);

			return this.BolSpecialOfferMapper.MapBOToModel(this.DalSpecialOfferMapper.MapEFToBO(records));
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
				return this.BolSpecialOfferMapper.MapBOToModel(this.DalSpecialOfferMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferServerResponseModel>> Create(
			ApiSpecialOfferServerRequestModel model)
		{
			CreateResponse<ApiSpecialOfferServerResponseModel> response = ValidationResponseFactory<ApiSpecialOfferServerResponseModel>.CreateResponse(await this.SpecialOfferModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSpecialOfferMapper.MapModelToBO(default(int), model);
				var record = await this.SpecialOfferRepository.Create(this.DalSpecialOfferMapper.MapBOToEF(bo));

				var businessObject = this.DalSpecialOfferMapper.MapEFToBO(record);
				response.SetRecord(this.BolSpecialOfferMapper.MapBOToModel(businessObject));
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
				var bo = this.BolSpecialOfferMapper.MapModelToBO(specialOfferID, model);
				await this.SpecialOfferRepository.Update(this.DalSpecialOfferMapper.MapBOToEF(bo));

				var record = await this.SpecialOfferRepository.Get(specialOfferID);

				var businessObject = this.DalSpecialOfferMapper.MapEFToBO(record);
				var apiModel = this.BolSpecialOfferMapper.MapBOToModel(businessObject);
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
				return this.BolSpecialOfferMapper.MapBOToModel(this.DalSpecialOfferMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>b7aec11243b788cb3112929fb757fb7e</Hash>
</Codenesium>*/