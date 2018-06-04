using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractPenService: AbstractService
	{
		private IPenRepository penRepository;
		private IApiPenRequestModelValidator penModelValidator;
		private IBOLPenMapper BOLPenMapper;
		private IDALPenMapper DALPenMapper;
		private ILogger logger;

		public AbstractPenService(
			ILogger logger,
			IPenRepository penRepository,
			IApiPenRequestModelValidator penModelValidator,
			IBOLPenMapper bolpenMapper,
			IDALPenMapper dalpenMapper)
			: base()

		{
			this.penRepository = penRepository;
			this.penModelValidator = penModelValidator;
			this.BOLPenMapper = bolpenMapper;
			this.DALPenMapper = dalpenMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPenResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.penRepository.All(skip, take, orderClause);

			return this.BOLPenMapper.MapBOToModel(this.DALPenMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPenResponseModel> Get(int id)
		{
			var record = await penRepository.Get(id);

			return this.BOLPenMapper.MapBOToModel(this.DALPenMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPenResponseModel>> Create(
			ApiPenRequestModel model)
		{
			CreateResponse<ApiPenResponseModel> response = new CreateResponse<ApiPenResponseModel>(await this.penModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPenMapper.MapModelToBO(default (int), model);
				var record = await this.penRepository.Create(this.DALPenMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPenMapper.MapBOToModel(this.DALPenMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPenRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLPenMapper.MapModelToBO(id, model);
				await this.penRepository.Update(this.DALPenMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.penRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e0da199045d547db043f03b133ec2870</Hash>
</Codenesium>*/