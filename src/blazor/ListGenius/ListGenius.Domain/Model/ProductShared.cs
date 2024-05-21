﻿using ListGenius.Domain.Model.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ListGenius.Domain.Model
{
    [Table("products_shared")]
    public class ProductShared : BaseEntity
    {
        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("value", TypeName = "decimal(18,2)")]
        public decimal Value { get; set; } = decimal.Zero;

        [Column("description")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Column("qrcode", TypeName = "varbinary(max)")]
        public byte[] Qrcode { get; set; } = [];

        [Column("image", TypeName = "varbinary(max)")]
        public byte[] Image { get; set; } = [];

        [Column("link")]
        [MaxLength(500)]
        public string Link { get; set; } = string.Empty;

        [Required]
        [Column("enabled")]
        [DefaultValue(true)]
        public bool Enabled { get; set; } = true;

        [Required]
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Column("unit")]
        [MaxLength(30)]
        public string Unit { get; set; } = string.Empty;

        [Required]
        [ForeignKey("product_groups")]
        [Column("id_product_groups")]
        [DefaultValue(0)]
        public int IdProductGroups { get; set; } = 0;

        [Required]
        [ForeignKey("product_sub_groups")]
        [Column("id_product_sub_groups")]
        [DefaultValue(0)]
        public int IdProductSubGroups { get; set; } = 0;

        [JsonIgnore]
        [NotMapped]
        public virtual ProductGroup ProductGroup { get; set; } = new ProductGroup();

        [JsonIgnore]
        [NotMapped]
        public virtual ProductSubGroup ProductSubGroup { get; set; } = new ProductSubGroup();
    }
}
