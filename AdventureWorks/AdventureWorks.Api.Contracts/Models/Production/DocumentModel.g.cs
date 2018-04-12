using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class DocumentModel
	{
		public DocumentModel()
		{}

		public DocumentModel(
			Nullable<short> documentLevel,
			string title,
			int owner,
			bool folderFlag,
			string fileName,
			string fileExtension,
			string revision,
			int changeNumber,
			int status,
			string documentSummary,
			byte[] document1,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.DocumentLevel = documentLevel;
			this.Title = title;
			this.Owner = owner.ToInt();
			this.FolderFlag = folderFlag;
			this.FileName = fileName;
			this.FileExtension = fileExtension;
			this.Revision = revision;
			this.ChangeNumber = changeNumber.ToInt();
			this.Status = status;
			this.DocumentSummary = documentSummary;
			this.Document1 = document1;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private Nullable<short> documentLevel;

		public Nullable<short> DocumentLevel
		{
			get
			{
				return this.documentLevel.IsEmptyOrZeroOrNull() ? null : this.documentLevel;
			}

			set
			{
				this.documentLevel = value;
			}
		}

		private string title;

		[Required]
		public string Title
		{
			get
			{
				return this.title;
			}

			set
			{
				this.title = value;
			}
		}

		private int owner;

		[Required]
		public int Owner
		{
			get
			{
				return this.owner;
			}

			set
			{
				this.owner = value;
			}
		}

		private bool folderFlag;

		[Required]
		public bool FolderFlag
		{
			get
			{
				return this.folderFlag;
			}

			set
			{
				this.folderFlag = value;
			}
		}

		private string fileName;

		[Required]
		public string FileName
		{
			get
			{
				return this.fileName;
			}

			set
			{
				this.fileName = value;
			}
		}

		private string fileExtension;

		[Required]
		public string FileExtension
		{
			get
			{
				return this.fileExtension;
			}

			set
			{
				this.fileExtension = value;
			}
		}

		private string revision;

		[Required]
		public string Revision
		{
			get
			{
				return this.revision;
			}

			set
			{
				this.revision = value;
			}
		}

		private int changeNumber;

		[Required]
		public int ChangeNumber
		{
			get
			{
				return this.changeNumber;
			}

			set
			{
				this.changeNumber = value;
			}
		}

		private int status;

		[Required]
		public int Status
		{
			get
			{
				return this.status;
			}

			set
			{
				this.status = value;
			}
		}

		private string documentSummary;

		public string DocumentSummary
		{
			get
			{
				return this.documentSummary.IsEmptyOrZeroOrNull() ? null : this.documentSummary;
			}

			set
			{
				this.documentSummary = value;
			}
		}

		private byte[] document1;

		public byte[] Document1
		{
			get
			{
				return this.document1.IsEmptyOrZeroOrNull() ? null : this.document1;
			}

			set
			{
				this.document1 = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>489a85fee4f6472a442020f56ff8620f</Hash>
</Codenesium>*/