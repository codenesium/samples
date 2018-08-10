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
	public abstract class AbstractCertificateService : AbstractService
	{
		protected ICertificateRepository CertificateRepository { get; private set; }

		protected IApiCertificateRequestModelValidator CertificateModelValidator { get; private set; }

		protected IBOLCertificateMapper BolCertificateMapper { get; private set; }

		protected IDALCertificateMapper DalCertificateMapper { get; private set; }

		private ILogger logger;

		public AbstractCertificateService(
			ILogger logger,
			ICertificateRepository certificateRepository,
			IApiCertificateRequestModelValidator certificateModelValidator,
			IBOLCertificateMapper bolCertificateMapper,
			IDALCertificateMapper dalCertificateMapper)
			: base()
		{
			this.CertificateRepository = certificateRepository;
			this.CertificateModelValidator = certificateModelValidator;
			this.BolCertificateMapper = bolCertificateMapper;
			this.DalCertificateMapper = dalCertificateMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCertificateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CertificateRepository.All(limit, offset);

			return this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCertificateResponseModel> Get(string id)
		{
			var record = await this.CertificateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCertificateResponseModel>> Create(
			ApiCertificateRequestModel model)
		{
			CreateResponse<ApiCertificateResponseModel> response = new CreateResponse<ApiCertificateResponseModel>(await this.CertificateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCertificateMapper.MapModelToBO(default(string), model);
				var record = await this.CertificateRepository.Create(this.DalCertificateMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCertificateResponseModel>> Update(
			string id,
			ApiCertificateRequestModel model)
		{
			var validationResult = await this.CertificateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCertificateMapper.MapModelToBO(id, model);
				await this.CertificateRepository.Update(this.DalCertificateMapper.MapBOToEF(bo));

				var record = await this.CertificateRepository.Get(id);

				return new UpdateResponse<ApiCertificateResponseModel>(this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCertificateResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.CertificateModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CertificateRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiCertificateResponseModel>> ByCreated(DateTimeOffset created)
		{
			List<Certificate> records = await this.CertificateRepository.ByCreated(created);

			return this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(records));
		}

		public async Task<List<ApiCertificateResponseModel>> ByDataVersion(byte[] dataVersion)
		{
			List<Certificate> records = await this.CertificateRepository.ByDataVersion(dataVersion);

			return this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(records));
		}

		public async Task<List<ApiCertificateResponseModel>> ByNotAfter(DateTimeOffset notAfter)
		{
			List<Certificate> records = await this.CertificateRepository.ByNotAfter(notAfter);

			return this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(records));
		}

		public async Task<List<ApiCertificateResponseModel>> ByThumbprint(string thumbprint)
		{
			List<Certificate> records = await this.CertificateRepository.ByThumbprint(thumbprint);

			return this.BolCertificateMapper.MapBOToModel(this.DalCertificateMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>08c64db81c8caa708d359d1357fdf933</Hash>
</Codenesium>*/