using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractAirlineService : AbstractService
	{
		private IMediator mediator;

		protected IAirlineRepository AirlineRepository { get; private set; }

		protected IApiAirlineServerRequestModelValidator AirlineModelValidator { get; private set; }

		protected IBOLAirlineMapper BolAirlineMapper { get; private set; }

		protected IDALAirlineMapper DalAirlineMapper { get; private set; }

		private ILogger logger;

		public AbstractAirlineService(
			ILogger logger,
			IMediator mediator,
			IAirlineRepository airlineRepository,
			IApiAirlineServerRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper bolAirlineMapper,
			IDALAirlineMapper dalAirlineMapper)
			: base()
		{
			this.AirlineRepository = airlineRepository;
			this.AirlineModelValidator = airlineModelValidator;
			this.BolAirlineMapper = bolAirlineMapper;
			this.DalAirlineMapper = dalAirlineMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAirlineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AirlineRepository.All(limit, offset);

			return this.BolAirlineMapper.MapBOToModel(this.DalAirlineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAirlineServerResponseModel> Get(int id)
		{
			var record = await this.AirlineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAirlineMapper.MapBOToModel(this.DalAirlineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAirlineServerResponseModel>> Create(
			ApiAirlineServerRequestModel model)
		{
			CreateResponse<ApiAirlineServerResponseModel> response = ValidationResponseFactory<ApiAirlineServerResponseModel>.CreateResponse(await this.AirlineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolAirlineMapper.MapModelToBO(default(int), model);
				var record = await this.AirlineRepository.Create(this.DalAirlineMapper.MapBOToEF(bo));

				var businessObject = this.DalAirlineMapper.MapEFToBO(record);
				response.SetRecord(this.BolAirlineMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new AirlineCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAirlineServerResponseModel>> Update(
			int id,
			ApiAirlineServerRequestModel model)
		{
			var validationResult = await this.AirlineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAirlineMapper.MapModelToBO(id, model);
				await this.AirlineRepository.Update(this.DalAirlineMapper.MapBOToEF(bo));

				var record = await this.AirlineRepository.Get(id);

				var businessObject = this.DalAirlineMapper.MapEFToBO(record);
				var apiModel = this.BolAirlineMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new AirlineUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiAirlineServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiAirlineServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AirlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.AirlineRepository.Delete(id);

				await this.mediator.Publish(new AirlineDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8dd09fc1ca5669a4c2830473e80d8172</Hash>
</Codenesium>*/