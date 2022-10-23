﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper.Contrib.Extensions;

using SimpleInventoryApp.Models.Standard;
using SimpleInventoryApp.Utilities.Attributes;

namespace SimpleInventoryApp.Models.Base
{
    //Subset of information for every instance, creates a general table structure.
    public abstract record class Instance
    {
        [Key] //Primary key
        public int InstanceId { get; set; }

        public int Name { get; set; }
        public string Description { get; set; }
        public bool SystemOwned { get; set; } // owned by original code or the user has defined this instance on top of this structure

        [Computed] //Indicates NOT to include the property on updates
        public CategoryCollection Categories { get; set; } = new CategoryCollection(); // The associated categories for the instance


        [Computed]
        public DateTime CreatedTimestamp { get; set; }

        [Computed]
        public CustomAttributes CustomAttributes { get; set; } = new CustomAttributes(); // Any custom attributes associated with this instance
    }

    //Table attributes for tables associated with the appropriate model.
    //Might need to decorate in models for these instances instead of here
    [Table("[Instances].[Categories]")] // tells Dapper.Contrib what table to perform the CRUD operations
    [PropertyTable("CustomAttributes", "[Instances].[CategoryAttributes]")] // ([propertyName, tableName])
    [PropertyTable("Categories", "[Instances].[CategoryCategories]")]
    public record class CategoryInstance : Instance
    {
        //...Properties
    }

    [Table("[Instances].[Products]")]
    [PropertyTable("CustomAttributes", "[Instances].[ProductAttributes]")]
    [PropertyTable("Categories", "[Instances].[ProductCategories]")]
    public record class ProductInstance : Instance
    {
        //...Properties
    }
}
