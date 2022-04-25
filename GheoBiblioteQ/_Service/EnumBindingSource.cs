using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GheoBiblioteQ._Service
{
    public class EnumBindingSource :MarkupExtension
    {

        public Type EnumType { get; private set; }

        public EnumBindingSource(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
            {
                throw new Exception("EnumTyp must not be null and of type Enum");
            }
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
