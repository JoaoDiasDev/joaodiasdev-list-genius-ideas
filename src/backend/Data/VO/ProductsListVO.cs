﻿using JoaoDiasDev.ListGenius.Hypermedia;
using JoaoDiasDev.ListGenius.Hypermedia.Abstract;
using System.Text.Json.Serialization;

namespace JoaoDiasDev.ListGenius.Data.VO
{
    public class ProductsListVO : ISupportsHyperMedia
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;
        [JsonPropertyName("public")]
        public bool Public { get; set; } = false;

        [JsonPropertyName("total_products_count")]
        public int TotalProductsCount { get; set; } = default;

        [JsonPropertyName("total_products_value")]
        public decimal TotalProductsValue { get; set; } = decimal.Zero;

        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
