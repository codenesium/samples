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

		protected IDALTestAllFieldTypeMapper DalTestAllFieldTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractTestAllFieldTypeService(
			ILogger logger,
			IMediator mediator,
			ITestAllFieldTypeRepository testAllFieldTypeRepository,
			IApiTestAllFieldTypeServerRequestModelValidator testAllFieldTypeModelValidator,
			IDALTestAllFieldTypeMapper dalTestAllFieldTypeMapper)
			: base()
		{
			this.TestAllFieldTypeRepository = testAllFieldTypeRepository;
			this.TestAllFieldTypeModelValidator = testAllFieldTypeModelValidator;
			this.DalTestAllFieldTypeMapper = dalTestAllFieldTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTestAllFieldTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TestAllFieldType> records = await this.TestAllFieldTypeRepository.All(limit, offset, query);

			return this.DalTestAllFieldTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTestAllFieldTypeServerResponseModel> Get(int id)
		{
			TestAllFieldType record = await this.TestAllFieldTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTestAllFieldTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypeServerResponseModel>> Create(
			ApiTestAllFieldTypeServerRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypeServerResponseModel> response = ValidationResponseFactory<ApiTestAllFieldTypeServerResponseModel>.CreateResponse(await this.TestAllFieldTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TestAllFieldType record = this.DalTestAllFieldTypeMapper.MapModelToEntity(default(int), model);
				record = await this.TestAllFieldTypeRepository.Create(record);

				response.SetRecord(this.DalTestAllFieldTypeMapper.MapEntityToModel(record));
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
				TestAllFieldType record = this.DalTestAllFieldTypeMapper.MapModelToEntity(id, model);
				await this.TestAllFieldTypeRepository.Update(record);

				record = await this.TestAllFieldTypeRepository.Get(id);

				ApiTestAllFieldTypeServerResponseModel apiModel = this.DalTestAllFieldTypeMapper.MapEntityToModel(record);
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
    <Hash>2711c997d2bc51602955b49cac75064a</Hash>
</Codenesium>*/