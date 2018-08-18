using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractNuGetPackageService : AbstractService
	{
		protected INuGetPackageRepository NuGetPackageRepository { get; private set; }

		protected IApiNuGetPackageRequestModelValidator NuGetPackageModelValidator { get; private set; }

		protected IBOLNuGetPackageMapper BolNuGetPackageMapper { get; private set; }

		protected IDALNuGetPackageMapper DalNuGetPackageMapper { get; private set; }

		private ILogger logger;

		public AbstractNuGetPackageService(
			ILogger logger,
			INuGetPackageRepository nuGetPackageRepository,
			IApiNuGetPackageRequestModelValidator nuGetPackageModelValidator,
			IBOLNuGetPackageMapper bolNuGetPackageMapper,
			IDALNuGetPackageMapper dalNuGetPackageMapper)
			: base()
		{
			this.NuGetPackageRepository = nuGetPackageRepository;
			this.NuGetPackageModelValidator = nuGetPackageModelValidator;
			this.BolNuGetPackageMapper = bolNuGetPackageMapper;
			this.DalNuGetPackageMapper = dalNuGetPackageMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiNuGetPackageResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.NuGetPackageRepository.All(limit, offset);

			return this.BolNuGetPackageMapper.MapBOToModel(this.DalNuGetPackageMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiNuGetPackageResponseModel> Get(string id)
		{
			var record = await this.NuGetPackageRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolNuGetPackageMapper.MapBOToModel(this.DalNuGetPackageMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiNuGetPackageResponseModel>> Create(
			ApiNuGetPackageRequestModel model)
		{
			CreateResponse<ApiNuGetPackageResponseModel> response = new CreateResponse<ApiNuGetPackageResponseModel>(await this.NuGetPackageModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolNuGetPackageMapper.MapModelToBO(default(string), model);
				var record = await this.NuGetPackageRepository.Create(this.DalNuGetPackageMapper.MapBOToEF(bo));

				response.SetRecord(this.BolNuGetPackageMapper.MapBOToModel(this.DalNuGetPackageMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiNuGetPackageResponseModel>> Update(
			string id,
			ApiNuGetPackageRequestModel model)
		{
			var validationResult = await this.NuGetPackageModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolNuGetPackageMapper.MapModelToBO(id, model);
				await this.NuGetPackageRepository.Update(this.DalNuGetPackageMapper.MapBOToEF(bo));

				var record = await this.NuGetPackageRepository.Get(id);

				return new UpdateResponse<ApiNuGetPackageResponseModel>(this.BolNuGetPackageMapper.MapBOToModel(this.DalNuGetPackageMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiNuGetPackageResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.NuGetPackageModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.NuGetPackageRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c12b90ffb1aa24beeaef0a1422963a71</Hash>
</Codenesium>*/