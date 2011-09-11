using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace WallPaperSeven.Utils
{
    [MarkupExtensionReturnType(typeof(object[]))]
    class EnumValuesProvider : MarkupExtension
    {
        public EnumValuesProvider()
        {
        }

        public EnumValuesProvider(Type enumType)
        {
            this.EnumType = enumType;
        }

        [ConstructorArgument("enumType")]
        public Type EnumType { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.EnumType == null || !this.EnumType.IsEnum)
                throw new ArgumentException("The enum type is not set or is not a enum type");
            return Enum.GetValues(this.EnumType);
        }
    }
}
