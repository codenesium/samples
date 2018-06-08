using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Password", Schema="Person")]
        public partial class Password: AbstractEntity
        {
                public Password()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        string passwordHash,
                        string passwordSalt,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PasswordHash = passwordHash;
                        this.PasswordSalt = passwordSalt;
                        this.Rowguid = rowguid;
                }

                [Key]
                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PasswordHash", TypeName="varchar(128)")]
                public string PasswordHash { get; private set; }

                [Column("PasswordSalt", TypeName="varchar(10)")]
                public string PasswordSalt { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c2b285a66a261407d367b6166c2807dc</Hash>
</Codenesium>*/