using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractPersonService : AbstractService
	{
		protected IPersonRepository PersonRepository { get; private set; }

		protected IApiPersonServerRequestModelValidator PersonModelValidator { get; private set; }

		protected IBOLPersonMapper BolPersonMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper)
			: base()
		{
			this.PersonRepository = personRepository;
			this.PersonModelValidator = personModelValidator;
			this.BolPersonMapper = bolPersonMapper;
			this.DalPersonMapper = dalPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonRepository.All(limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonServerResponseModel> Get(int personId)
		{
			var record = await this.PersonRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model)
		{
			CreateResponse<ApiPersonServerResponseModel> response = ValidationResponseFactory<ApiPersonServerResponseModel>.CreateResponse(await this.PersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPersonMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRepository.Create(this.DalPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonServerResponseModel>> Update(
			int personId,
			ApiPersonServerRequestModel model)
		{
			var validationResult = await this.PersonModelValidator.ValidateUpdateAsync(personId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonMapper.MapModelToBO(personId, model);
				await this.PersonRepository.Update(this.DalPersonMapper.MapBOToEF(bo));

				var record = await this.PersonRepository.Get(personId);

				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int personId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PersonModelValidator.ValidateDeleteAsync(personId));

			if (response.Success)
			{
				await this.PersonRepository.Delete(personId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e170ffeb5948f5f4418f9fba998880a2</Hash>
</Codenesium>*/