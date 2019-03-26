using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBusinessEntityService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IBusinessEntityRepository BusinessEntityRepository { get; private set; }

		protected IApiBusinessEntityServerRequestModelValidator BusinessEntityModelValidator { get; private set; }

		protected IDALBusinessEntityMapper DalBusinessEntityMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractBusinessEntityService(
			ILogger logger,
			MediatR.IMediator mediator,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityServerRequestModelValidator businessEntityModelValidator,
			IDALBusinessEntityMapper dalBusinessEntityMapper,
			IDALPersonMapper dalPersonMapper)
			: base()
		{
			this.BusinessEntityRepository = businessEntityRepository;
			this.BusinessEntityModelValidator = businessEntityModelValidator;
			this.DalBusinessEntityMapper = dalBusinessEntityMapper;
			this.DalPersonMapper = dalPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBusinessEntityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<BusinessEntity> records = await this.BusinessEntityRepository.All(limit, offset, query);

			return this.DalBusinessEntityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiBusinessEntityServerResponseModel> Get(int businessEntityID)
		{
			BusinessEntity record = await this.BusinessEntityRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalBusinessEntityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityServerResponseModel>> Create(
			ApiBusinessEntityServerRequestModel model)
		{
			CreateResponse<ApiBusinessEntityServerResponseModel> response = ValidationResponseFactory<ApiBusinessEntityServerResponseModel>.CreateResponse(await this.BusinessEntityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				BusinessEntity record = this.DalBusinessEntityMapper.MapModelToEntity(default(int), model);
				record = await this.BusinessEntityRepository.Create(record);

				response.SetRecord(this.DalBusinessEntityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new BusinessEntityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityServerResponseModel>> Update(
			int businessEntityID,
			ApiBusinessEntityServerRequestModel model)
		{
			var validationResult = await this.BusinessEntityModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				BusinessEntity record = this.DalBusinessEntityMapper.MapModelToEntity(businessEntityID, model);
				await this.BusinessEntityRepository.Update(record);

				record = await this.BusinessEntityRepository.Get(businessEntityID);

				ApiBusinessEntityServerResponseModel apiModel = this.DalBusinessEntityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new BusinessEntityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiBusinessEntityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiBusinessEntityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.BusinessEntityModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.BusinessEntityRepository.Delete(businessEntityID);

				await this.mediator.Publish(new BusinessEntityDeletedNotification(businessEntityID));
			}

			return response;
		}

		public async virtual Task<ApiBusinessEntityServerResponseModel> ByRowguid(Guid rowguid)
		{
			BusinessEntity record = await this.BusinessEntityRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalBusinessEntityMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> PeopleByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<Person> records = await this.BusinessEntityRepository.PeopleByBusinessEntityID(businessEntityID, limit, offset);

			return this.DalPersonMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f8efd38672ef37f33c6ecdb0a362d3c4</Hash>
</Codenesium>*/