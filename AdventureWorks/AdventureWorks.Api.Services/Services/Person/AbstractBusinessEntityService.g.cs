using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBusinessEntityService : AbstractService
	{
		private IMediator mediator;

		protected IBusinessEntityRepository BusinessEntityRepository { get; private set; }

		protected IApiBusinessEntityServerRequestModelValidator BusinessEntityModelValidator { get; private set; }

		protected IBOLBusinessEntityMapper BolBusinessEntityMapper { get; private set; }

		protected IDALBusinessEntityMapper DalBusinessEntityMapper { get; private set; }

		protected IBOLPersonMapper BolPersonMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractBusinessEntityService(
			ILogger logger,
			IMediator mediator,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityServerRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper bolBusinessEntityMapper,
			IDALBusinessEntityMapper dalBusinessEntityMapper,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper)
			: base()
		{
			this.BusinessEntityRepository = businessEntityRepository;
			this.BusinessEntityModelValidator = businessEntityModelValidator;
			this.BolBusinessEntityMapper = bolBusinessEntityMapper;
			this.DalBusinessEntityMapper = dalBusinessEntityMapper;
			this.BolPersonMapper = bolPersonMapper;
			this.DalPersonMapper = dalPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBusinessEntityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BusinessEntityRepository.All(limit, offset);

			return this.BolBusinessEntityMapper.MapBOToModel(this.DalBusinessEntityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityServerResponseModel> Get(int businessEntityID)
		{
			var record = await this.BusinessEntityRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBusinessEntityMapper.MapBOToModel(this.DalBusinessEntityMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityServerResponseModel>> Create(
			ApiBusinessEntityServerRequestModel model)
		{
			CreateResponse<ApiBusinessEntityServerResponseModel> response = ValidationResponseFactory<ApiBusinessEntityServerResponseModel>.CreateResponse(await this.BusinessEntityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolBusinessEntityMapper.MapModelToBO(default(int), model);
				var record = await this.BusinessEntityRepository.Create(this.DalBusinessEntityMapper.MapBOToEF(bo));

				var businessObject = this.DalBusinessEntityMapper.MapEFToBO(record);
				response.SetRecord(this.BolBusinessEntityMapper.MapBOToModel(businessObject));
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
				var bo = this.BolBusinessEntityMapper.MapModelToBO(businessEntityID, model);
				await this.BusinessEntityRepository.Update(this.DalBusinessEntityMapper.MapBOToEF(bo));

				var record = await this.BusinessEntityRepository.Get(businessEntityID);

				var businessObject = this.DalBusinessEntityMapper.MapEFToBO(record);
				var apiModel = this.BolBusinessEntityMapper.MapBOToModel(businessObject);
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
				return this.BolBusinessEntityMapper.MapBOToModel(this.DalBusinessEntityMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiPersonServerResponseModel>> PeopleByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<Person> records = await this.BusinessEntityRepository.PeopleByBusinessEntityID(businessEntityID, limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1f8b49380f35ac68ea43a9452083ae78</Hash>
</Codenesium>*/