﻿namespace TestManagmentSystem.Data.Common.CodeFirstConvention
{
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using TestManagmentSystem.Data.Common.DataAnnotations;

    public class IsUnicodeAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<IsUnicodeAttribute>
    {
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, IsUnicodeAttribute attribute)
        {
            configuration.IsUnicode(attribute.IsUnicode);
        }
    }
}
