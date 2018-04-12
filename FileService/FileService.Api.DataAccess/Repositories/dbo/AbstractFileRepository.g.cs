using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractFileRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractFileRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			Guid externalId,
			string privateKey,
			string publicKey,
			string location,
			DateTime expiration,
			string extension,
			DateTime dateCreated,
			decimal fileSizeInBytes,
			int fileTypeId,
			Nullable<int> bucketId,
			string description)
		{
			var record = new EFFile();

			MapPOCOToEF(
				0,
				externalId,
				privateKey,
				publicKey,
				location,
				expiration,
				extension,
				dateCreated,
				fileSizeInBytes,
				fileTypeId,
				bucketId,
				description,
				record);

			this.context.Set<EFFile>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			Guid externalId,
			string privateKey,
			string publicKey,
			string location,
			DateTime expiration,
			string extension,
			DateTime dateCreated,
			decimal fileSizeInBytes,
			int fileTypeId,
			Nullable<int> bucketId,
			string description)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				MapPOCOToEF(
					id,
					externalId,
					privateKey,
					publicKey,
					location,
					expiration,
					extension,
					dateCreated,
					fileSizeInBytes,
					fileTypeId,
					bucketId,
					description,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFFile>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOFile GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Files.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOFile> GetWhereDirect(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Files;
		}

		private void SearchLinqPOCO(Expression<Func<EFFile, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFFile> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFFile> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFFile> SearchLinqEF(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFFile> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			Guid externalId,
			string privateKey,
			string publicKey,
			string location,
			DateTime expiration,
			string extension,
			DateTime dateCreated,
			decimal fileSizeInBytes,
			int fileTypeId,
			Nullable<int> bucketId,
			string description,
			EFFile efFile)
		{
			efFile.SetProperties(id.ToInt(), externalId, privateKey, publicKey, location, expiration.ToDateTime(), extension, dateCreated.ToDateTime(), fileSizeInBytes.ToDecimal(), fileTypeId.ToInt(), bucketId.ToNullableInt(), description);
		}

		public static void MapEFToPOCO(
			EFFile efFile,
			Response response)
		{
			if (efFile == null)
			{
				return;
			}

			response.AddFile(new POCOFile(efFile.Id.ToInt(), efFile.ExternalId, efFile.PrivateKey, efFile.PublicKey, efFile.Location, efFile.Expiration.ToDateTime(), efFile.Extension, efFile.DateCreated.ToDateTime(), efFile.FileSizeInBytes.ToDecimal(), efFile.FileTypeId.ToInt(), efFile.BucketId.ToNullableInt(), efFile.Description));

			FileTypeRepository.MapEFToPOCO(efFile.FileType, response);

			BucketRepository.MapEFToPOCO(efFile.Bucket, response);
		}
	}
}

/*<Codenesium>
    <Hash>ab4e775b70f8b5f5e94f53299f9a505b</Hash>
</Codenesium>*/