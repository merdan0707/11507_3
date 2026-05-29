using System.Reflection;

namespace ReflectionClass.Homework.Utils.MyMapper;

public class MapperImpl : IMapper
{
    public void Map<TSource, TDest>(TSource source, TDest dest)
    {
        if (source == null || dest == null) return;

        var propertiesSource = typeof(TSource).GetProperties();
        var propertiesDest = typeof(TDest).GetProperties();

        foreach (var propSource in propertiesSource)
        {
            var propDest = propertiesDest.FirstOrDefault(p => 
                p.Name == propSource.Name && 
                p.PropertyType == propSource.PropertyType &&
                p.CanWrite);

            if (propDest != null)
            {
                var value = propSource.GetValue(source);
                propDest.SetValue(dest, value);
            }
        }
    }
}