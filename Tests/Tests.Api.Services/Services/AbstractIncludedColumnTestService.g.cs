using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractIncludedColumnTestService : AbstractService
	{
		private IMediator mediator;

		protected IIncludedColumnTestRepository IncludedColumnTestRepository { get; private set; }

		protected IApiIncludedColumnTestServerRequestModelValidator IncludedColumnTestModelValidator { get; private set; }

		protected IDALIncludedColumnTestMapper DalIncludedColumnTestMapper { get; private set; }

		private ILogger logger;

		public AbstractIncludedColumnTestService(
			ILogger logger,
			IMediator mediator,
			IIncludedColumnTestRepository includedColumnTestRepository,
			IApiIncludedColumnTestServerRequestModelValidator includedColumnTestModelValidator,
			IDALIncludedColumnTestMapper dalIncludedColumnTestMapper)
			: base()
		{
			this.IncludedColumnTestRepository = includedColumnTestRepository;
			this.IncludedColumnTestModelValidator = includedColumnTestModelValidator;
			this.DalIncludedColumnTestMapper = dalIncludedColumnTestMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiIncludedColumnTestServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<IncludedColumnTest> records = await this.IncludedColumnTestRepository.All(limit, offset, query);

			return this.DalIncludedColumnTestMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiIncludedColumnTestServerResponseModel> Get(int id)
		{
			IncludedColumnTest record = await this.IncludedColumnTestRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalIncludedColumnTestMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiIncludedColumnTestServerResponseModel>> Create(
			ApiIncludedColumnTestServerRequestModel model)
		{
			CreateResponse<ApiIncludedColumnTestServerResponseModel> response = ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.CreateResponse(await this.IncludedColumnTestModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				IncludedColumnTest record = this.DalIncludedColumnTestMapper.MapModelToEntity(default(int), model);
				record = await this.IncludedColumnTestRepository.Create(record);

				response.SetRecord(this.DalIncludedColumnTestMapper.MapEntityToModel(record));
				await this.mediator.Publish(new IncludedColumnTestCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiIncludedColumnTestServerResponseModel>> Update(
			int id,
			ApiIncludedColumnTestServerRequestModel model)
		{
			var validationResult = await this.IncludedColumnTestModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				IncludedColumnTest record = this.DalIncludedColumnTestMapper.MapModelToEntity(id, model);
				await this.IncludedColumnTestRepository.Update(record);

				record = await this.IncludedColumnTestRepository.Get(id);

				ApiIncludedColumnTestServerResponseModel apiModel = this.DalIncludedColumnTestMapper.MapEntityToModel(record);
				await this.mediator.Publish(new IncludedColumnTestUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.IncludedColumnTestModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.IncludedColumnTestRepository.Delete(id);

				await this.mediator.Publish(new IncludedColumnTestDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>37f87b5f9142ca1c0b7fead542bb0a67</Hash>
</Codenesium>*/