using System.Runtime.InteropServices.ComTypes;
using AutoMapper;

namespace Arma3BEClient.Common.Extensions
{
    public static class GenericExtensions
    {
        public static TK Map<TK>(this object source)
        {
            return Mapper.DynamicMap<TK>(source);
        }
    }
}