﻿using OnlineRetailer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineRetailer.Areas.Admin.Models
{
    public class ItemModel
    {
        public ItemModel()
        {

        }

        public ItemModel(Item item)
        {
            Id = item.Id;
            ManufacturerId = item.ManufacturerId;
            ModelNumber = item.ModelNumber;
            SKU = item.SKU;
            UPCCode = item.UPCCode;
            ShortDescription = item.ShortDescription;
            LongDescription = item.LongDescription;
            ImageURL = item.ImageURL;
            CategoryId = item.CategoryId;
            ListPrice = item.ListPrice;
            SalePrice = item.SalePrice;
            Discount = item.Discount;
            InStock = item.InStock;
            Quantity = item.Quantity;
            IsDailySpecial = item.IsDailySpecial;
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Manufacturer Id")]
        public int ManufacturerId { get; set; }

        public string Manufacturer
        {
            get
            {
                return Manufacturers == null || Manufacturers.Count.Equals(0) ?
                    string.Empty : Manufacturers.SingleOrDefault(
                    c => c.Id.Equals(ManufacturerId)).Name;
            }
        }

        [DisplayName("Manufactrer")]
        public ICollection<Manufacturer> Manufacturers { get; set; }

        [Required]
        [DisplayName("Model Number")]
        public string ModelNumber { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        [DisplayName("UPC Code")]
        public string UPCCode { get; set; }

        [Required]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }

        [DisplayName("Image URL")]
        public string ImageURL { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public string Category
        {
            get
            {
                return Categories == null || Categories.Count.Equals(0) ?
                    string.Empty : Categories.SingleOrDefault(
                        c => c.Id.Equals(CategoryId)).Name;
            }
        }

        [DisplayName("Category")]
        public ICollection<Category> Categories { get; set; }

        [Required]
        [DisplayName("List Price")]
        public float ListPrice { get; set; }

        [Required]
        [DisplayName("Sale Price")]
        public float SalePrice { get; set; }

        public double Discount
        {
            get { return Math.Round((1 - (SalePrice / ListPrice)) * 100); }
            set { }
        }

        [DisplayName("In Stock")]
        public bool InStock { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DisplayName("Daily Special")]
        public bool IsDailySpecial { get; set; }

    }
}