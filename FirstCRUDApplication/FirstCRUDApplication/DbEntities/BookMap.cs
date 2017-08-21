using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCRUDApplication.DbEntities
{
    public class BookMap 
    {
        public BookMap(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);            
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.ISBN).IsRequired();
            entityBuilder.Property(t => t.Author).IsRequired();
            entityBuilder.Property(t => t.Publisher).IsRequired();           
        }
    }
}
