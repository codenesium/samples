using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractPersonService : AbstractService
	{
		protected IPersonRepository PersonRepository { get; private set; }

		protected IApiPersonRequestModelValidator PersonModelValidator { get; private set; }

		protected IBOLPersonMapper BolPersonMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
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

		public virtual async Task<List<ApiPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonRepository.All(limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonResponseModel> Get(int personId)
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

		public virtual async Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model)
		{
			CreateResponse<ApiPersonResponseModel> response = new CreateResponse<ApiPersonResponseModel>(await this.PersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPersonMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRepository.Create(this.DalPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonResponseModel>> Update(
			int personId,
			ApiPersonRequestModel model)
		{
			var validationResult = await this.PersonModelValidator.ValidateUpdateAsync(personId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonMapper.MapModelToBO(personId, model);
				await this.PersonRepository.Update(this.DalPersonMapper.MapBOToEF(bo));

				var record = await this.PersonRepository.Get(personId);

				return new UpdateResponse<ApiPersonResponseModel>(this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int personId)
		{
			ActionResponse response = new ActionResponse(await this.PersonModelValidator.ValidateDeleteAsync(personId));
			if (response.Success)
			{
				await this.PersonRepository.Delete(personId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a0ca3c6d1988afa33eefada6882292d1</Hash>
</Codenesium>*/