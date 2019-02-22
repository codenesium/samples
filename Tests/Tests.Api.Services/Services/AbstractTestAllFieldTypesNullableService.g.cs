using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTestAllFieldTypesNullableService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ITestAllFieldTypesNullableRepository TestAllFieldTypesNullableRepository { get; private set; }

		protected IApiTestAllFieldTypesNullableServerRequestModelValidator TestAllFieldTypesNullableModelValidator { get; private set; }

		protected IDALTestAllFieldTypesNullableMapper DalTestAllFieldTypesNullableMapper { get; private set; }

		private ILogger logger;

		public AbstractTestAllFieldTypesNullableService(
			ILogger logger,
			MediatR.IMediator mediator,
			ITestAllFieldTypesNullableRepository testAllFieldTypesNullableRepository,
			IApiTestAllFieldTypesNullableServerRequestModelValidator testAllFieldTypesNullableModelValidator,
			IDALTestAllFieldTypesNullableMapper dalTestAllFieldTypesNullableMapper)
			: base()
		{
			this.TestAllFieldTypesNullableRepository = testAllFieldTypesNullableRepository;
			this.TestAllFieldTypesNullableModelValidator = testAllFieldTypesNullableModelValidator;
			this.DalTestAllFieldTypesNullableMapper = dalTestAllFieldTypesNullableMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTestAllFieldTypesNullableServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TestAllFieldTypesNullable> records = await this.TestAllFieldTypesNullableRepository.All(limit, offset, query);

			return this.DalTestAllFieldTypesNullableMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTestAllFieldTypesNullableServerResponseModel> Get(int id)
		{
			TestAllFieldTypesNullable record = await this.TestAllFieldTypesNullableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTestAllFieldTypesNullableMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>> Create(
			ApiTestAllFieldTypesNullableServerRequestModel model)
		{
			CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel> response = ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.CreateResponse(await this.TestAllFieldTypesNullableModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TestAllFieldTypesNullable record = this.DalTestAllFieldTypesNullableMapper.MapModelToEntity(default(int), model);
				record = await this.TestAllFieldTypesNullableRepository.Create(record);

				response.SetRecord(this.DalTestAllFieldTypesNullableMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TestAllFieldTypesNullableCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>> Update(
			int id,
			ApiTestAllFieldTypesNullableServerRequestModel model)
		{
			var validationResult = await this.TestAllFieldTypesNullableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TestAllFieldTypesNullable record = this.DalTestAllFieldTypesNullableMapper.MapModelToEntity(id, model);
				await this.TestAllFieldTypesNullableRepository.Update(record);

				record = await this.TestAllFieldTypesNullableRepository.Get(id);

				ApiTestAllFieldTypesNullableServerResponseModel apiModel = this.DalTestAllFieldTypesNullableMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TestAllFieldTypesNullableUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTestAllFieldTypesNullableServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TestAllFieldTypesNullableModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TestAllFieldTypesNullableRepository.Delete(id);

				await this.mediator.Publish(new TestAllFieldTypesNullableDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dfc5fef5e9471269bde2453ac5e6c760</Hash>
</Codenesium>*/