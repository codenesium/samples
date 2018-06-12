using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("LibraryVariableSet", Schema="dbo")]
        public partial class LibraryVariableSet: AbstractEntity
        {
                public LibraryVariableSet()
                {
                }

                public void SetProperties(
                        string contentType,
                        string id,
                        string jSON,
                        string name,
                        string variableSetId)
                {
                        this.ContentType = contentType;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.VariableSetId = variableSetId;
                }

                [Column("ContentType", TypeName="nvarchar(50)")]
                public string ContentType { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("VariableSetId", TypeName="nvarchar(150)")]
                public string VariableSetId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8a81d9e3633923dc445ec2b4a3474f4d</Hash>
</Codenesium>*/