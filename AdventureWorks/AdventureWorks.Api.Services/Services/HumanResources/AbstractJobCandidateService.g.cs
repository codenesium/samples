using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractJobCandidateService : AbstractService
	{
		protected IJobCandidateRepository JobCandidateRepository { get; private set; }

		protected IApiJobCandidateRequestModelValidator JobCandidateModelValidator { get; private set; }

		protected IBOLJobCandidateMapper BolJobCandidateMapper { get; private set; }

		protected IDALJobCandidateMapper DalJobCandidateMapper { get; private set; }

		private ILogger logger;

		public AbstractJobCandidateService(
			ILogger logger,
			IJobCandidateRepository jobCandidateRepository,
			IApiJobCandidateRequestModelValidator jobCandidateModelValidator,
			IBOLJobCandidateMapper bolJobCandidateMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base()
		{
			this.JobCandidateRepository = jobCandidateRepository;
			this.JobCandidateModelValidator = jobCandidateModelValidator;
			this.BolJobCandidateMapper = bolJobCandidateMapper;
			this.DalJobCandidateMapper = dalJobCandidateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiJobCandidateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.JobCandidateRepository.All(limit, offset);

			return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiJobCandidateResponseModel> Get(int jobCandidateID)
		{
			var record = await this.JobCandidateRepository.Get(jobCandidateID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiJobCandidateResponseModel>> Create(
			ApiJobCandidateRequestModel model)
		{
			CreateResponse<ApiJobCandidateResponseModel> response = new CreateResponse<ApiJobCandidateResponseModel>(await this.JobCandidateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolJobCandidateMapper.MapModelToBO(default(int), model);
				var record = await this.JobCandidateRepository.Create(this.DalJobCandidateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiJobCandidateResponseModel>> Update(
			int jobCandidateID,
			ApiJobCandidateRequestModel model)
		{
			var validationResult = await this.JobCandidateModelValidator.ValidateUpdateAsync(jobCandidateID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolJobCandidateMapper.MapModelToBO(jobCandidateID, model);
				await this.JobCandidateRepository.Update(this.DalJobCandidateMapper.MapBOToEF(bo));

				var record = await this.JobCandidateRepository.Get(jobCandidateID);

				return new UpdateResponse<ApiJobCandidateResponseModel>(this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiJobCandidateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int jobCandidateID)
		{
			ActionResponse response = new ActionResponse(await this.JobCandidateModelValidator.ValidateDeleteAsync(jobCandidateID));
			if (response.Success)
			{
				await this.JobCandidateRepository.Delete(jobCandidateID);
			}

			return response;
		}

		public async Task<List<ApiJobCandidateResponseModel>> ByBusinessEntityID(int? businessEntityID)
		{
			List<JobCandidate> records = await this.JobCandidateRepository.ByBusinessEntityID(businessEntityID);

			return this.BolJobCandidateMapper.MapBOToModel(this.DalJobCandidateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7c838e8a33d1eb9e9978441af8962a38</Hash>
</Codenesium>*/