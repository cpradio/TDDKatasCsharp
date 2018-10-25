using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Katas.Mocking.Extensions
{
	public static class SerializeExtension
	{
		public static byte[] BinarySerialize<T>(this T o)
		{
			using (var buffer = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(buffer, o);
				buffer.Position = 0;

				return buffer.ToArray();
			}
		}
	}
}
