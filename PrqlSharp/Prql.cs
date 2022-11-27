using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PrqlSharp
{
    public class Prql
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MutString
        {
            public IntPtr string_ptr;
        }

        [DllImport("libprql_lib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "to_sql")]
        internal static extern Int32 to_sql(string input, [MarshalAs(UnmanagedType.LPStr)] StringBuilder output);

        [DllImport("libprql_lib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "to_json")]
        internal static extern Int32 to_json(string input, [MarshalAs(UnmanagedType.LPStr)] StringBuilder output);

        [DllImport("libprql_lib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "from_json")]
        internal static extern Int32 from_json(string input, [MarshalAs(UnmanagedType.LPStr)] StringBuilder output);

        public static string ToSql(string prqlQuery)
        {
            var inPtr = Marshal.StringToHGlobalAnsi(prqlQuery);
            var output = new StringBuilder(prqlQuery.Length * 32);
            var response = to_sql(prqlQuery, output);
            if (response != 0)
            {
                throw new ArgumentException(output.ToString());
            }
            return output.ToString();
        }

        public static string FromJson(string jsonQuery)
        {
            var inPtr = Marshal.StringToHGlobalAnsi(jsonQuery);
            var output = new StringBuilder(jsonQuery.Length * 32);
            var response = from_json(jsonQuery, output);
            if (response != 0)
            {
                throw new ArgumentException(output.ToString());
            }
            return output.ToString();
        }

        public static string ToJson(string prqlQuery)
        {
            var inPtr = Marshal.StringToHGlobalAnsi(prqlQuery);
            var output = new StringBuilder(prqlQuery.Length * 32);
            var response = to_json(prqlQuery, output);
            if (response != 0)
            {
                throw new ArgumentException(output.ToString());
            }
            return output.ToString();
        }
    }
}