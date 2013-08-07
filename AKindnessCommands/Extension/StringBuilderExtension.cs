using System.Text;
using AKindnessCommands.Formating;

namespace AKindnessCommands.Extension
{
	public static
	class StringBuilderExtension
	{
		public static
		TOut Form<TOut>(this StringBuilder self, Format<StringBuilder,TOut> format)
		{
			return format.Apply( self );
		}
	}
}