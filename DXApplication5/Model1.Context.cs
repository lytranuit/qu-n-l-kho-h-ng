﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXApplication5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class projectEntities : DbContext
    {
        public projectEntities()
            : base("name=projectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<inventory> inventories { get; set; }
        public DbSet<issue> issues { get; set; }
        public DbSet<issue_product> issue_product { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<receipt> receipts { get; set; }
        public DbSet<receipt_product> receipt_product { get; set; }
    }
}
