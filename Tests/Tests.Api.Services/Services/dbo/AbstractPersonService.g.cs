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
		private IPersonRepository personRepository;

		private IApiPersonRequestModelValidator personModelValidator;

		private IBOLPersonMapper bolPersonMapper;

		private IDALPersonMapper dalPersonMapper;

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IPersonRepository personRepository,
			IApiPersonRequestModelValidator personModelValidator,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper)
			: base()
		{
			this.personRepository = personRepository;
			this.personModelValidator = personModelValidator;
			this.bolPersonMapper = bolPersonMapper;
			this.dalPersonMapper = dalPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.personRepository.All(limit, offset);

			return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonResponseModel> Get(int personId)
		{
			var record = await this.personRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model)
		{
			CreateResponse<ApiPersonResponseModel> response = new CreateResponse<ApiPersonResponseModel>(await this.personModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPersonMapper.MapModelToBO(default(int), model);
				var record = await this.personRepository.Create(this.dalPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonResponseModel>> Update(
			int personId,
			ApiPersonRequestModel model)
		{
			var validationResult = await this.personModelValidator.ValidateUpdateAsync(personId, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolPersonMapper.MapModelToBO(personId, model);
				await this.personRepository.Update(this.dalPersonMapper.MapBOToEF(bo));

				var record = await this.personRepository.Get(personId);

				return new UpdateResponse<ApiPersonResponseModel>(this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int personId)
		{
			ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateDeleteAsync(personId));
			if (response.Success)
			{
				await this.personRepository.Delete(personId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5b29cf87502797047a40274861c1d174</Hash>
</Codenesium>*/