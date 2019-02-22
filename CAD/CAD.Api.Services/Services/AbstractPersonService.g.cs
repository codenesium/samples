using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractPersonService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPersonRepository PersonRepository { get; private set; }

		protected IApiPersonServerRequestModelValidator PersonModelValidator { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		protected IDALCallPersonMapper DalCallPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IDALPersonMapper dalPersonMapper,
			IDALCallPersonMapper dalCallPersonMapper)
			: base()
		{
			this.PersonRepository = personRepository;
			this.PersonModelValidator = personModelValidator;
			this.DalPersonMapper = dalPersonMapper;
			this.DalCallPersonMapper = dalCallPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Person> records = await this.PersonRepository.All(limit, offset, query);

			return this.DalPersonMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPersonServerResponseModel> Get(int id)
		{
			Person record = await this.PersonRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPersonMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model)
		{
			CreateResponse<ApiPersonServerResponseModel> response = ValidationResponseFactory<ApiPersonServerResponseModel>.CreateResponse(await this.PersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Person record = this.DalPersonMapper.MapModelToEntity(default(int), model);
				record = await this.PersonRepository.Create(record);

				response.SetRecord(this.DalPersonMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PersonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonServerResponseModel>> Update(
			int id,
			ApiPersonServerRequestModel model)
		{
			var validationResult = await this.PersonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Person record = this.DalPersonMapper.MapModelToEntity(id, model);
				await this.PersonRepository.Update(record);

				record = await this.PersonRepository.Get(id);

				ApiPersonServerResponseModel apiModel = this.DalPersonMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PersonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PersonModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PersonRepository.Delete(id);

				await this.mediator.Publish(new PersonDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallPersonServerResponseModel>> CallPersonsByPersonId(int personId, int limit = int.MaxValue, int offset = 0)
		{
			List<CallPerson> records = await this.PersonRepository.CallPersonsByPersonId(personId, limit, offset);

			return this.DalCallPersonMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>c8b2bd4396e1e6089009ab708a7cf564</Hash>
</Codenesium>*/