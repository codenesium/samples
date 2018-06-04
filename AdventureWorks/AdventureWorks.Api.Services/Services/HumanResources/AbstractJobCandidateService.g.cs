using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractJobCandidateService: AbstractService
	{
		private IJobCandidateRepository jobCandidateRepository;
		private IApiJobCandidateRequestModelValidator jobCandidateModelValidator;
		private IBOLJobCandidateMapper BOLJobCandidateMapper;
		private IDALJobCandidateMapper DALJobCandidateMapper;
		private ILogger logger;

		public AbstractJobCandidateService(
			ILogger logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper boljobCandidateMapper,
			IDALJobCandidateMapper daljobCandidateMapper)
			: base()

		{
			this.jobCandidateRepository = jobCandidateRepository;
			this.jobCandidateModelValidator = jobCandidateModelValidator;
			this.BOLJobCandidateMapper = boljobCandidateMapper;
			this.DALJobCandidateMapper = daljobCandidateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.jobCandidateRepository.All(skip, take, orderClause);

			return this.BOLJobCandidateMapper.MapBOToModel(this.DALJobCandidateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiJobCandidateResponseModel> Get(int jobCandidateID)
		{
			var record = await jobCandidateRepository.Get(jobCandidateID);

			return this.BOLJobCandidateMapper.MapBOToModel(this.DALJobCandidateMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiJobCandidateResponseModel>> Create(
			ApiJobCandidateRequestModel model)
		{
			CreateResponse<ApiJobCandidateResponseModel> response = new CreateResponse<ApiJobCandidateResponseModel>(await this.jobCandidateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLJobCandidateMapper.MapModelToBO(default (int), model);
				var record = await this.jobCandidateRepository.Create(this.DALJobCandidateMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLJobCandidateMapper.MapBOToModel(this.DALJobCandidateMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int jobCandidateID,
			ApiJobCandidateRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateUpdateAsync(jobCandidateID, model));

			if (response.Success)
			{
				var bo = this.BOLJobCandidateMapper.MapModelToBO(jobCandidateID, model);
				await this.jobCandidateRepository.Update(this.DALJobCandidateMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int jobCandidateID)
		{
			ActionResponse response = new ActionResponse(await this.jobCandidateModelValidator.ValidateDeleteAsync(jobCandidateID));

			if (response.Success)
			{
				await this.jobCandidateRepository.Delete(jobCandidateID);
			}
			return response;
		}

		public async Task<List<ApiJobCandidateResponseModel>> GetBusinessEntityID(Nullable<int> businessEntityID)
		{
			List<JobCandidate> records = await this.jobCandidateRepository.GetBusinessEntityID(businessEntityID);

			return this.BOLJobCandidateMapper.MapBOToModel(this.DALJobCandidateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>27ccae3ed7d6c47abdad7157664c5ecf</Hash>
</Codenesium>*/