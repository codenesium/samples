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

		public AbstractFileRepository(ILogger logger,
		                              ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(Guid externalId,
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
			var record = new EFFile ();

			MapPOCOToEF(0, externalId,
			            privateKey,
			            publicKey,
			            location,
			            expiration,
			            extension,
			            dateCreated,
			            fileSizeInBytes,
			            fileTypeId,
			            bucketId,
			            description, record);

			this.context.Set<EFFile>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, Guid externalId,
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
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  externalId,
				            privateKey,
				            publicKey,
				            location,
				            expiration,
				            extension,
				            dateCreated,
				            fileSizeInBytes,
				            fileTypeId,
				            bucketId,
				            description, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
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

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFFile> SearchLinqEF(Expression<Func<EFFile, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFFile> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFFile, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOFile> GetWhereDirect(Expression<Func<EFFile, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Files;
		}
		public virtual POCOFile GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.Files.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFFile, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFFile> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFFile> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, Guid externalId,
		                               string privateKey,
		                               string publicKey,
		                               string location,
		                               DateTime expiration,
		                               string extension,
		                               DateTime dateCreated,
		                               decimal fileSizeInBytes,
		                               int fileTypeId,
		                               Nullable<int> bucketId,
		                               string description, EFFile   efFile)
		{
			efFile.Id = id;
			efFile.ExternalId = externalId;
			efFile.PrivateKey = privateKey;
			efFile.PublicKey = publicKey;
			efFile.Location = location;
			efFile.Expiration = expiration;
			efFile.Extension = extension;
			efFile.DateCreated = dateCreated;
			efFile.FileSizeInBytes = fileSizeInBytes;
			efFile.FileTypeId = fileTypeId;
			efFile.BucketId = bucketId;
			efFile.Description = description;
		}

		public static void MapEFToPOCO(EFFile efFile,Response response)
		{
			if(efFile == null)
			{
				return;
			}
			response.AddFile(new POCOFile()
			{
				Id = efFile.Id.ToInt(),
				ExternalId = efFile.ExternalId,
				PrivateKey = efFile.PrivateKey,
				PublicKey = efFile.PublicKey,
				Location = efFile.Location,
				Expiration = efFile.Expiration.ToDateTime(),
				Extension = efFile.Extension,
				DateCreated = efFile.DateCreated.ToDateTime(),
				FileSizeInBytes = efFile.FileSizeInBytes.ToDecimal(),
				Description = efFile.Description,

				FileTypeId = new ReferenceEntity<int>(efFile.FileTypeId,
				                                      "FileTypes"),
				BucketId = new ReferenceEntity<Nullable<int>>(efFile.BucketId,
				                                              "Buckets"),
			});

			FileTypeRepository.MapEFToPOCO(efFile.FileType, response);

			BucketRepository.MapEFToPOCO(efFile.Bucket, response);
		}
	}
}

/*<Codenesium>
    <Hash>b6ddd1c32530a82251b5665e5a4df93d</Hash>
</Codenesium>*/