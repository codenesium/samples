using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTestAllFieldTypeService : AbstractService
	{
		private IMediator mediator;

		protected ITestAllFieldTypeRepository TestAllFieldTypeRepository { get; private set; }

		protected IApiTestAllFieldTypeServerRequestModelValidator TestAllFieldTypeModelValidator { get; private set; }

		protected IBOLTestAllFieldTypeMapper BolTestAllFieldTypeMapper { get; private set; }

		protected IDALTestAllFieldTypeMapper DalTestAllFieldTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractTestAllFieldTypeService(
			ILogger logger,
			IMediator mediator,
			ITestAllFieldTypeRepository testAllFieldTypeRepository,
			IApiTestAllFieldTypeServerRequestModelValidator testAllFieldTypeModelValidator,
			IBOLTestAllFieldTypeMapper bolTestAllFieldTypeMapper,
			IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper)
			: base()
		{
			this.TestAllFieldTypeRepository = testAllFieldTypeRepository;
			this.TestAllFieldTypeModelValidator = testAllFieldTypeModelValidator;
			this.BolTestAllFieldTypeMapper = bolTestAllFieldTypeMapper;
			this.DalTestAllFieldTypeMapper = dalTestAllFieldTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTestAllFieldTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TestAllFieldTypeRepository.All(limit, offset);

			return this.BolTestAllFieldTypeMapper.MapBOToModel(this.DalTestAllFieldTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTestAllFieldTypeServerResponseModel> Get(int id)
		{
			var record = await this.TestAllFieldTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTestAllFieldTypeMapper.MapBOToModel(this.DalTestAllFieldTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypeServerResponseModel>> Create(
			ApiTestAllFieldTypeServerRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypeServerResponseModel> response = ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.CreateResponse(await this.TestAllFieldTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTestAllFieldTypeMapper.MapModelToBO(default(int), model);
				var record = await this.TestAllFieldTypeRepository.Create(this.DalTestAllFieldTypeMapper.MapBOToEF(bo));

				var businessObject = this.DalTestAllFieldTypeMapper.MapEFToBO(record);
				response.SetRecord(this.BolTestAllFieldTypeMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new TestAllFieldTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>> Update(
			int id,
			ApiTestAllFieldTypeServerRequestModel model)
		{
			var validationResult = await this.TestAllFieldTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTestAllFieldTypeMapper.MapModelToBO(id, model);
				await this.TestAllFieldTypeRepository.Update(this.DalTestAllFieldTypeMapper.MapBOToEF(bo));

				var record = await this.TestAllFieldTypeRepository.Get(id);

				var businessObject = this.DalTestAllFieldTypeMapper.MapEFToBO(record);
				var apiModel = this.BolTestAllFieldTypeMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new TestAllFieldTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TestAllFieldTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TestAllFieldTypeRepository.Delete(id);

				await this.mediator.Publish(new TestAllFieldTypeDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1a884abf42e1c9f3e71c3c4e69856c77</Hash>
</Codenesium>*/